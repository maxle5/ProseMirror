using HtmlAgilityPack;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Superscript : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "sup";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                Type = "superscript"
            };
        }
    }
}
