using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace ProseMirror.Net.Nodes
{
    internal class Heading : INode
    {
        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.Heading,
                Attrs = new()
                {
                    Level = GetLevel(node.Name)
                }
            };
        }

        public bool Matches(HtmlNode node)
        {
            return GetLevel(node.Name).HasValue;
        }

        private static int? GetLevel(string tagName)
        {
            var match = Regex.Match(tagName, "^h([1-6])$");
            return match.Success ? System.Convert.ToInt32(match.Groups[1].Value) : null;
        }
    }
}
