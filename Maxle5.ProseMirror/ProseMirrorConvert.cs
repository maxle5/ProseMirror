using Maxle5.ProseMirror.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Maxle5.ProseMirror
{
    public static class ProseMirrorConvert
    {
        public static string SerializeToHtml(Node rootNode)
        {
            return new HtmlConverter().Convert(rootNode);
        }

        public static string SerializeToJson(Node rootNode)
        {
            return JsonConvert.SerializeObject(rootNode, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static Node DeserializeObjectFromHtml(string html)
        {
            return new HtmlConverter().Convert(html);
        }

        public static Node DeserializeObjectFromJson(string json)
        {
            return JsonConvert.DeserializeObject<Node>(json);
        }
    }
}