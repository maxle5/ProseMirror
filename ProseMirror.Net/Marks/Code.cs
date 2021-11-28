using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Marks
{
    internal class Code : IMark
    {
        public bool Matches(HtmlNode node)
        {
            if (node.ParentNode.Name == "pre")
            {
                return false;
            }

            return node.Name == "code";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new()
            {
                TypeEnum = MarkType.Code
            };
        }
    }
}
