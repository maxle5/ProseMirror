using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Bold : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "strong" || node.Name == "b";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                TypeEnum = MarkType.Bold
            };
        }
    }
}
