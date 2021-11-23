using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using NearX.Models;
using NearX.Services;
using NearX.Utilities;


namespace NearX.Pages
{

    public class IndexBase : ComponentBase, IAsyncDisposable
    {
        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;
        protected MapStateViewModel MapStateViewModel;
        protected MarkerViewModel MarkerViewModel;

        [Inject] private ISnackbar _snackbar { get; set; }

        [Inject] private IHttpClientFactory _httpClientFactory { get; set; }
        public IndexBase() : base()
        {

            var mapCentre = new LatLng(-42, 175); // Centred on New Zealand
            MapStateViewModel = new MapStateViewModel
            {
                MapCentreLatitude = mapCentre.Lat,
                MapCentreLongitude = mapCentre.Lng,
                Zoom = 4
            };
            PositionMap = new Map("testMap", new MapOptions
            {
                Center = mapCentre,
                Zoom = MapStateViewModel.Zoom
            });
            PositionMap.SubscribeToEvents();


            OpenStreetMapsTileLayer = new TileLayer(
                "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                new TileLayerOptions
                {
                    Attribution = @"Map data &copy; <a href=""https://www.openstreetmap.org/"">OpenStreetMap</a> contributors, " +
                        @"<a href=""https://creativecommons.org/licenses/by-sa/2.0/"">CC-BY-SA</a>"
                }
            );

            MarkerViewModel = new MarkerViewModel();

        }

        public async Task WireMeUp()
        {
            await PositionMap.SubscribeToEvents();
            PositionMap.OnMoveEnd += async (mymap, e) =>
            {
                

                Map currentMap = (Map)mymap;

                var mapCentre = await PositionMap.GetCenter();
                double latCenter = mapCentre.Lat;
                double lngCenter = mapCentre.Lng;

                MapPoint mp = new MapPoint()
                {
                    Latitude = latCenter,
                    Longitude = lngCenter
                };
                // box will be 20km by 20km
                
                int currentZoom = await PositionMap.GetZoom();
                Console.WriteLine($"ZOOM: {currentZoom}");
                double area = 100 / (currentZoom * 0.5);

                // dont search if area is too large
                if (area < 20)
                {
                    _snackbar.Add("Finding Cafes.", Severity.Success);
                    Console.WriteLine($"ZOOM: {currentZoom} Area: {area}");
                    var bounds = BoxUtility.GetBoundingBox(mp, area);

                    Console.WriteLine(
                        $"result of bounding calculation minlat:{bounds.MinPoint.Latitude}, minlng:{bounds.MinPoint.Longitude}," +
                        $" maxlat:{bounds.MaxPoint.Latitude}, maxlng:{bounds.MaxPoint.Longitude}");

                    List<LatLng> boxPoints = new List<LatLng>();
                    LatLng pa = new LatLng(bounds.MinPoint.Latitude, bounds.MinPoint.Longitude);
                    LatLng pb = new LatLng(bounds.MaxPoint.Latitude, bounds.MinPoint.Longitude);
                    LatLng pc = new LatLng(bounds.MaxPoint.Latitude, bounds.MaxPoint.Longitude);
                    LatLng pd = new LatLng(bounds.MinPoint.Latitude, bounds.MaxPoint.Longitude);
                    LatLng pe = new LatLng(bounds.MinPoint.Latitude, bounds.MinPoint.Longitude);

                    boxPoints.Add(pa);
                    boxPoints.Add(pb);
                    boxPoints.Add(pc);
                    boxPoints.Add(pd);
                    boxPoints.Add(pe);

                    Polyline searchArea = new Polyline(boxPoints, null);
                    await searchArea.AddTo(PositionMap);

                    string box =
                        $" ({bounds.MinPoint.Latitude},{bounds.MinPoint.Longitude},{bounds.MaxPoint.Latitude},{bounds.MaxPoint.Longitude})";
                    OverpassService oService = new OverpassService(_httpClientFactory);
                    var res = await oService.GetCafesAsync("cafe", box);


                    foreach (var cafe in res.elements)
                    {
                        AddCafeMarkerAtLatLng(cafe);
                    }

                    await searchArea.Remove();
                }

                else
                {
                    _snackbar.Add("Area to large to search for Cafes.", Severity.Normal);
                }
            };
        }

        [JSInvokable]
        public async Task SetMyLocationAsync(string passedValue)
        {
            _snackbar.Add("Located You !", Severity.Success);
            string[] latlngArray = passedValue.Split(":");
            double lat = double.Parse(latlngArray[0]);
            double lon = double.Parse(latlngArray[1]);
            var myLocation = new LatLng(lat, lon);
            await PositionMap.SetView(myLocation, 17);

            AddMarkerAtLatLng(new LatLng(lat, lon));

        }

        protected async void GetMapState()
        {
            var mapCentre = await PositionMap.GetCenter();
            MapStateViewModel.MapCentreLatitude = mapCentre.Lat;
            MapStateViewModel.MapCentreLongitude = mapCentre.Lng;
            MapStateViewModel.Zoom = await PositionMap.GetZoom();
            MapStateViewModel.MapContainerSize = await PositionMap.GetSize();
            MapStateViewModel.MapViewPixelBounds = await PositionMap.GetPixelBounds();
            MapStateViewModel.MapLayerPixelOrigin = await PositionMap.GetPixelOrigin();
            StateHasChanged();
        }

        protected async void SetMapState()
        {
            var mapCentre = new LatLng(MapStateViewModel.MapCentreLatitude, MapStateViewModel.MapCentreLongitude);
            await PositionMap.SetView(mapCentre, MapStateViewModel.Zoom);

        }

        protected async void AddCafeMarkerAtLatLng(Element cafElement)
        {
            LatLng cafeLatLng = new LatLng(cafElement.lat, cafElement.lon);
            var parentDiv = $@"<div>";
            var titleHtml = @$"<div class=""grow2"" >";
            if (!string.IsNullOrEmpty(cafElement.tags.name)) { titleHtml += $@"<divSTYLE=""font-weight:bold""> {cafElement.tags.name}<div>"; }
            if (!string.IsNullOrEmpty(cafElement.tags.brand)) { titleHtml += $"<div>{cafElement.tags.brand}<div>"; }
            if (!string.IsNullOrEmpty(cafElement.tags.description)) { titleHtml += $"<div>{cafElement.tags.description}<div>"; }
            if (!string.IsNullOrEmpty(cafElement.tags.website)) { titleHtml += $"<div>{cafElement.tags.website}<div>"; }
            if (!string.IsNullOrEmpty(cafElement.tags.phone)) { titleHtml += $"<div>{cafElement.tags.phone}<div>"; }

            if (!string.IsNullOrEmpty(cafElement.tags.opening_hours)) { titleHtml += $"<div>{cafElement.tags.opening_hours}<div>"; }

            string address = $"{cafElement.tags.addrhousenumber} {cafElement.tags.addrstreet} {cafElement.tags.addrhousenumber} {cafElement.tags.addrcity} {cafElement.tags.addrpostcode}";

            if (!string.IsNullOrEmpty(address)) { titleHtml += $"<div>{address}<div>"; }

            titleHtml += "</div>";

            var div = @"
                <div class=""xx"">
                    <img src=""/images/icons8-cafe-30.png"" class=""my-marker""/ >
                </div>";
            div += titleHtml;
            parentDiv += div;
            parentDiv += "</div>";
            //var div = @"
            //<div style=""background-color: #00000088; border-radius: 10px; padding: 16px;width: 80px"">
            //    <img src=""/images/home.png""/>
            //</div>
            //";

            var divIcon = new DivIcon(new DivIconOptions() { Html = parentDiv });

            // var icon = new Icon(new IconOptions()
            // {
            //     IconUrl = "leaf-orange.png",
            //     IconSize = new Point(64, 64)
            // });

            //";

            var marker = new Marker(cafeLatLng, new MarkerOptions
            {
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
            });
            
            await marker.AddTo(PositionMap);
            //await icon.AddTo(marker);
            await divIcon.AddTo(marker);
        }

        protected async void AddMarkerAtLatLng(LatLng latlng)
        {

            var div = @"
                <div class="" blob red"">
                <img src=""/images/icons8-home-24.png"" class=""my-marker""/ >
                </div>
            ";

            //var div = @"
            //<div style=""background-color: #00000088; border-radius: 10px; padding: 16px;width: 80px"">
            //    <img src=""/images/home.png""/>
            //</div>
            //";

            var divIcon = new DivIcon(new DivIconOptions() { Html = div });

            // var icon = new Icon(new IconOptions()
            // {
            //     IconUrl = "leaf-orange.png",
            //     IconSize = new Point(64, 64)
            // });


            var marker = new Marker(latlng, new MarkerOptions
            {
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
            });

            await marker.AddTo(PositionMap);
            //await icon.AddTo(marker);
            await divIcon.AddTo(marker);
        }
        protected async void AddMarkerAtMapCenter()
        {
            var mapCentre = await PositionMap.GetCenter();

            var div = @"
            <div style=""background-color: #00000088; border-radius: 10px; padding: 16px;width: 80px"">
                <img src=""leaf-red.png""/>
            </div>
            ";

            var divIcon = new DivIcon(new DivIconOptions() { Html = div });

            // var icon = new Icon(new IconOptions()
            // {
            //     IconUrl = "leaf-orange.png",
            //     IconSize = new Point(64, 64)
            // });

            var marker = new Marker(mapCentre, new MarkerOptions
            {
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
            });

            await marker.AddTo(PositionMap);
            //await icon.AddTo(marker);
            await divIcon.AddTo(marker);
        }

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }
    }
}
