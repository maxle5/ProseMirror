using HtmlAgilityPack;
using System.Net;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class TextNode : Node
    {
        public string Text { get; set; }

        public TextNode(HtmlNode node) : base("text")
        {
            Text = WebUtility.HtmlDecode(node.InnerText.TrimStart('\n'));
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode(WebUtility.HtmlEncode(Text));
        }
    }
}