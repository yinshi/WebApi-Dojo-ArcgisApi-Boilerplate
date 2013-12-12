define(['dojo/_base/declare', 'dojo/_base/array', 'esri/map', 'esri/layers/ArcGISDynamicMapServiceLayer'],
function (declare, Array, Map, ArcGISDynamicMapServiceLayer) {
    return declare(null, {
        _mapDivName: null,
        _baseMapURL: null,
        _dynamicServices: null,
        _map: null,

        constructor: function (mapDivName, baseMapURL, dynamicServices) {
            this._mapDivName = mapDivName;
            this._baseMapURL = baseMapURL;
            this._dynamicServices = dynamicServices;

            //Create map
            this._map = new Map(this._mapDivName, { center: [-86.636, 40.882], zoom: 10 });
            this.processDynamicLayers(this._dynamicServices);
        },

        ToggleLayer: function (serviceID, layerPosition, checked) {
            var selectedService = this._map.getLayer(serviceID);
            if (checked) {
                if (selectedService.visibleLayers[0] == -1)
                    selectedService.setVisibleLayers([layerPosition]);
                else {
                    var visibleLayers = selectedService.visibleLayers;
                    visibleLayers.push(layerPosition);
                    selectedService.setVisibleLayers(visibleLayers);
                }
            }
            else {
                var visibleLayers = selectedService.visibleLayers;
                if (visibleLayers.length == 1)
                    selectedService.setVisibleLayers([-1]);
                else {
                    var index = visibleLayers.indexOf(layerPosition);
                    visibleLayers.splice(index, 1);
                    selectedService.setVisibleLayers(visibleLayers);
                }
            }
        },

        processDynamicLayers: function (dynamicServices) {
            var layers = [];
            //Add base layer
            var baseLayer = new ArcGISDynamicMapServiceLayer(this._baseMapURL);
            layers.push(baseLayer);
            //Add dynamic layer
            Array.forEach(dynamicServices, function (dynamicService, i) {
                var layer = new ArcGISDynamicMapServiceLayer(dynamicService.URL, { id: dynamicService.id });
                layer.setVisibleLayers([-1]);
                layers.push(layer);
            });
            this._map.addLayers(layers);
        }
    });
});