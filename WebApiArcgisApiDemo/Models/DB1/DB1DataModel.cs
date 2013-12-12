using System.Collections.Generic;

namespace WebApiArcgisApiDemo.Models.DB1
{
    public class ESRIService
    {
        public int id { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public List<ESRILayer> Layers { get; set; }
    }

    public class ESRILayer
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int LayerPosition { get; set; }
        public string ImageURL { get; set; }
    }
}