using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Linq;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class ImageAttributes : NodeAttributes
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Alt { get; set; }
        public string Src { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Title { get; set; }
        public int? Width { get; set; }
    }

    internal class Image : NodeDefinition
    {
        public Image(HtmlNode node) : base("image")
        {
            Attrs = new ImageAttributes
            {
                Alt = node.Attributes.FirstOrDefault(a => a.Name == "alt")?.Value,
                Src = node.Attributes.FirstOrDefault(a => a.Name == "src")?.Value,
                Title = node.Attributes.FirstOrDefault(a => a.Name == "title")?.Value,
                Width = int.TryParse(node.Attributes.FirstOrDefault(a => a.Name == "width")?.Value, out var intVal) ? (int?)intVal : null
            };
        }
    }
}