using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class Text : INode
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "#text";
        }

        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            var text = node.InnerText.TrimStart('\n');

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.Text,
                Text = text,
            };
        }
    }
}