using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class Table : INode
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "tbody" &&
                   node.ParentNode.Name == "table";
        }

        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                Type = "table"
            };
        }
    }
}
