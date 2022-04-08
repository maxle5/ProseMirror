using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Builders
{
    internal class CodeBlockNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "code" && htmlNode.ParentNode.Name == "pre";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new CodeBlock();
        }
    }
}
