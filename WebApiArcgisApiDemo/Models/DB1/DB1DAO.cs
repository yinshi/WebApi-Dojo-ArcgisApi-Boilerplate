using System.Collections.Generic;
using System.Linq;

namespace WebApiArcgisApiDemo.Models.DB1
{
    public class DB1DAO: IDAO
    {
        public List<object> GetTable(string queryKey, List<string> parameterList = null)
        {
            List<object> returnList = new List<object>();
            if (queryKey.ToLower() == "getservices")
                returnList = GetServices();
            return returnList;
        }

        private List<object> GetServices()
        {
            List<ESRIService> serviceList = new List<ESRIService> ();
            ESRIService service0 = new ESRIService();
            service0.id = 280;
            service0.Name = "Sample data of the US";
            service0.URL = @"http://sampleserver6.arcgisonline.com/arcgis/rest/services/USA/MapServer";
  
            List<ESRILayer> layerList = new List<ESRILayer> ();
            ESRILayer layer0 = new ESRILayer();
            layer0.id = 0;
            layer0.LayerPosition = 0;
            layer0.Name = "Cities";
            layerList.Add(layer0);
            ESRILayer layer1 = new ESRILayer();
            layer1.id = 1;
            layer1.LayerPosition = 1;
            layer1.Name = "Highways";
            layerList.Add(layer1);
            ESRILayer layer2 = new ESRILayer();
            layer2.id = 2;
            layer2.LayerPosition = 2;
            layer2.Name = "States";
            layerList.Add(layer2);
            ESRILayer layer3 = new ESRILayer();
            layer3.id = 3;
            layer3.LayerPosition = 3;
            layer3.Name = "Counties";
            layerList.Add(layer3);
            service0.Layers = layerList;
            serviceList.Add(service0);

            return serviceList.OfType<object>().ToList();
        }
    }
}