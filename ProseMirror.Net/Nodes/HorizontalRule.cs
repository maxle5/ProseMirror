using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class HorizontalRule : INode
    {
        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.HorizontalRule,
            };
        }

        public bool Matches(HtmlNode node)
        {
            return node.Name == "hr";
        }
    }
}
