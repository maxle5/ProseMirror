using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Strike : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "strike" ||
                   node.Name == "s" ||
                   node.Name == "del";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                TypeEnum = MarkType.Strike
            };
        }
    }
}
