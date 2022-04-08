using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Builders
{
    internal class HeadingNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "h1" || htmlNode.Name == "h2" || htmlNode.Name == "h3" || htmlNode.Name == "h4" || htmlNode.Name == "h5" || htmlNode.Name == "h6";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new Heading(htmlNode);
        }
    }
}
