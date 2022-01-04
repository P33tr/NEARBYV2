using System;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A clickable, draggable icon that can be added to a <see cref="Map"/>
    /// <see href="https://leafletjs.com/reference-1.7.1.html#marker"/>
    /// </summary>
    public class Marker : InteractiveLayer
    {
        private bool subscribedToEvents = false;
        public EventHandler<LeafletMouseEventArgs> OnClick;
        private DotNetObjectReference<Marker> objectReference;

        /// <summary>
        /// Subscribe to the map events. Unless this is called the map will not raise events.
        /// </summary>
        public async Task SubscribeToEvents()
        {
            if (!subscribedToEvents)
            {
                Console.WriteLine("Subscribing to events");
                //await SubscribeToEvent("moveend", nameof(InvokeOnMoveEnd));
                await SubscribeToMouseEvent("click", nameof(InvokeOnClick));
                //await SubscribeToMouseEvent("dblclick", nameof(InvokeOnDoubleClick));
                //await SubscribeToMouseEvent("mousedown", nameof(InvokeOnMouseDown));
                //await SubscribeToMouseEvent("mouseup", nameof(InvokeOnMouseUp));
                //await SubscribeToMouseEvent("mouseover", nameof(InvokeOnMouseOver));
                //await SubscribeToMouseEvent("mouseout", nameof(InvokeOnMouseOut));
                //await SubscribeToMouseEvent("mousemove", nameof(InvokeOnMouseMove));
                //await SubscribeToMouseEvent("contextmenu", nameof(InvokeOnContextMenu));

                //This one causes a DOM Exception:
                //await SubscribeToMouseEvent("preclick", nameof(InvokeOnPreClick));

                subscribedToEvents = true;
            }
        }
        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnClick(LeafletMouseEventArgs args) => OnClick?.Invoke(this, args);

        private async Task SubscribeToMouseEvent(string eventName, string handlerName)
        {
            objectReference = objectReference ?? DotNetObjectReference.Create(this);
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Map.subscribeToMouseEvent", JSObjectReference, objectReference, eventName, handlerName);
        }

        /// <summary>
        /// The initial position of the marker.
        /// </summary>
        [JsonIgnore] public LatLng LatLng { get; }
        /// <summary>
        /// The <see cref="MarkerOptions"/> used to create the marker.
        /// </summary>
        [JsonIgnore] public MarkerOptions Options { get; }

        /// <summary>
        /// Constructs a marker
        /// </summary>
        /// <param name="latlng">The initial position of the marker.</param>
        /// <param name="options">The <see cref="MarkerOptions"/> used to create the marker.</param>
        public Marker(LatLng latlng, MarkerOptions options)
        {
            LatLng = latlng;
            Options = options;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.marker", LatLng, Options);
        }
    }
}
