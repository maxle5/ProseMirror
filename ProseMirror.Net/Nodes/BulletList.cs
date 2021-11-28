using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class BulletList : INode
    {
        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.BulletList,
            };
        }

        public bool Matches(HtmlNode node)
        {
            return node.Name == "ul";
        }
    }
}
