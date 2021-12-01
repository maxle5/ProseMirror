using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Maxle5.ProseMirror
{
    public static class ProseMirrorConvert
    {
        // TODO: implement
        //public static string SerializeToHtml(NodeDefinition rootNode)
        //{
        //    return new HtmlConverter().Convert(rootNode);
        //}

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