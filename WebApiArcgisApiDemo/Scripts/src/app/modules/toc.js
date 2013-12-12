define(['dojo/_base/declare', 'dojo/_base/array', 'dojo/_base/lang', 'cbtree/store/ObjectStore', 'cbtree/Tree', 'cbtree/model/ForestStoreModel', 'cbtree/extensions/TreeStyling', 'dojo/domReady!'],
function (declare, Array, Lang, ObjectStore, Tree, ForestStoreModel) {
    return declare(null, {
        _mapObj: null,

        constructor: function (dynamicServices, mapObj) {
            this._mapObj = mapObj;

            //Set tocdata for cbtree
            var tocData = [];
            var parentEntry = { id: "tableHeader", Name: "TOC" };
            tocData.push(parentEntry);
            Array.forEach(dynamicServices, function (dynamicService, i) {
                var serviceEntry = Lang.clone(dynamicService);
                serviceEntry.type = "service";
                serviceEntry.parent = "tableHeader";
                delete serviceEntry.Layers;
                tocData.push(serviceEntry);
                Array.forEach(dynamicService.Layers, function (dynamicLayer, i) {
                    var layerEntry = Lang.clone(dynamicLayer);
                    layerEntry.type = "layer";
                    layerEntry.parent = serviceEntry.id;
                    tocData.push(layerEntry);
                });
            });

            //Set up Store, Model, Tree
            var store = new ObjectStore({ data: tocData });
            var model = new ForestStoreModel({ store: store,
                labelAttr: 'Name',
                query: { id: "tableHeader" }
            });
            var tree = new Tree({ model: model, showRoot: false, id: "serviceTree" });
            tree.placeAt("tocDiv");
            tree.on("checkBoxClick", Lang.hitch(this, this.LayerClicked));
            tree.startup();

        },

        LayerClicked: function (item, treeNode, event) {
            if (item.type == "layer") {
                this._mapObj.ToggleLayer(item.parent, item.LayerPosition, item.checked);
            }
        }

    });     //Declare closing brackets
});             