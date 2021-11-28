using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;
using System.Linq;

namespace ProseMirror.Net.Nodes
{
    internal class Image : INode
    {
        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.Image,
                Attrs = new()
                {
                    Alt = node.Attributes.FirstOrDefault(a => a.Name == "alt")?.Value,
                    Src = node.Attributes.FirstOrDefault(a => a.Name == "src")?.Value,
                    Title = node.Attributes.FirstOrDefault(a => a.Name == "title")?.Value,
                }
            };
        }

        public bool Matches(HtmlNode node)
        {
            return node.Name == "img";
        }
    }
}
