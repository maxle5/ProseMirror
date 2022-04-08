using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class Document : Node
    {
        public Document() : base("doc")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<html></html>").AppendChild(HtmlNode.CreateNode("<body></body>"));
        }
    }
}