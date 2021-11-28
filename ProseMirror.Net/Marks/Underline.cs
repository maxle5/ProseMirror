using HtmlAgilityPack;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Underline : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "u";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                Type = "underline"
            };
        }
    }
}
