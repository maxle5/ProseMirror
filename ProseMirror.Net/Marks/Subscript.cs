using HtmlAgilityPack;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Subscript : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "sub";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                Type = "subscript"
            };
        }
    }
}
