using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;

namespace ProseMirror.Net.Nodes
{
    internal class CodeBlockWrapper : INode
    {
        public Node Data(HtmlNode node) => null;

        public bool Matches(HtmlNode node)
        {
            return node.Name == "pre";
        }
    }
}
