using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Builders
{
    internal class ParagraphNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "p";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new Paragraph(htmlNode);
        }
    }
}
