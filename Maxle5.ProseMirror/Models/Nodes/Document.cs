using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class Document : NodeDefinition
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