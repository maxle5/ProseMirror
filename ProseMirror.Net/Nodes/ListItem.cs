using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class ListItem : INode
    {
        public Node Wrapper { get; set; } = new StandardNode()
        {
            TypeEnum = NodeType.Paragraph
        };

        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            if (node.ChildNodes.Count == 1 &&
               node.ChildNodes[0].Name == "p")
            {
                Wrapper = null;
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.ListItem,
            };
        }

        public bool Matches(HtmlNode node)
        {
            return node.Name == "li";
        }
    }
}
