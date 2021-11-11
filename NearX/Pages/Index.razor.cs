﻿using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using NearX.Models;

namespace NearX.Pages
{
    public class IndexBase : ComponentBase, IAsyncDisposable
    {
        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;
        protected MapStateViewModel MapStateViewModel;
        protected MarkerViewModel MarkerViewModel;


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

        [JSInvokable]
        public async Task SetMyLocationAsync(string passedValue)
        {
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
