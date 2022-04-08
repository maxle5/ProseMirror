using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Builders
{
    internal class HorizontalRuleNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "hr";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new HorizontalRule();
        }
    }
}
