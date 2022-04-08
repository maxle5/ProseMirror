using HtmlAgilityPack;
using System.Collections.Generic;

namespace Maxle5.ProseMirror.Models
{
    public abstract class NodeAttributes
    {
    }

    public abstract class Node
    {
        public string Type { get; }
        public NodeAttributes Attrs { get; protected set; }
        public IEnumerable<Node> Content { get; set; }
        public IEnumerable<Mark> Marks { get; set; }

        protected Node(string type)
        {
            Type = type;
        }

        public abstract HtmlNode RenderHtmlNode();
    }
}