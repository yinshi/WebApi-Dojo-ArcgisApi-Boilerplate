define(['app/modules/map', 'app/modules/toc', 'dojo/parser', 'dojo/store/JsonRest', 'dojo/ready', 'dijit/layout/BorderContainer', 'dijit/layout/ContentPane'],
function (Map, TOC, Parser, JsonRest, READY) {
    READY(function () {
        Parser.parse();

        var basemapURL = 'http://services.arcgisonline.com/ArcGIS/rest/services/World_Terrain_Base/MapServer';

        this._dynamicServicesStore = new JsonRest({
            target: "../../api/DB1Services/"
        });

        // Query the entire aimt dynamic services
        this._dynamicServicesStore.query().then(function (dynamicServices) {
            var map = new Map('mapDiv', basemapURL, dynamicServices);
            var toc = new TOC(dynamicServices, map);
        });
    });
});
