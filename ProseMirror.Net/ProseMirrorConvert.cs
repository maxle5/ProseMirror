using ProseMirror.Model;

namespace ProseMirror.Net
{
    public static class ProseMirrorConvert
    {
        public static string SerializeToHtml(Node rootNode)
        {
            return Serializer.JSon.JSonSerializer.Serialize(rootNode);
        }

        public static string SerializeToJson(Node rootNode)
        {
            return Serializer.JSon.JSonSerializer.Serialize(rootNode);
        }

        public static Node DeserializeObjectFromHtml(string html)
        {
            return new HtmlConverter().Convert(html);
        }

        public static Node DeserializeObjectFromJson(string json)
        {
            return Serializer.JSon.JSonSerializer.Deserialize<Node>(json);
        }
    }
}
