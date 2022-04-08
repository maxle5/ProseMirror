using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;
using System.Linq;

namespace Maxle5.ProseMirror.Builders
{
    internal class TableNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "table" && !htmlNode.Descendants("tbody").Any() ||
                     htmlNode.Name == "tbody" && htmlNode.ParentNode.Name == "table";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new Table();
        }
    }
}
