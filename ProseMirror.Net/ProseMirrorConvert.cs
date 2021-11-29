using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProseMirror.Net.Models;
using ProseMirror.Net.Services;

namespace ProseMirror.Net
{
    public static class ProseMirrorConvert
    {
        public static string SerializeToHtml(NodeDefinition rootNode)
        {
            return new HtmlConverter().Convert(rootNode);
        }

        public static string SerializeToJson(NodeDefinition rootNode)
        {
            return JsonConvert.SerializeObject(rootNode, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public static NodeDefinition DeserializeObjectFromHtml(string html)
        {
            return new HtmlConverter().Convert(html);
        }

        public static NodeDefinition DeserializeObjectFromJson(string json)
        {
            return JsonConvert.DeserializeObject<NodeDefinition>(json);
        }
    }
}