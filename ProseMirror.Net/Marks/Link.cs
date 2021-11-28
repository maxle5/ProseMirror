using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;
using System.Linq;

namespace ProseMirror.Net.Marks
{
    internal class Link : IMark
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "a";
        }

        public Model.Marks Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            var data = new Model.Marks()
            {
                TypeEnum = MarkType.Link
            };

            var attrs = new MarkAttributes();
            var target = node.Attributes.FirstOrDefault(a => a.Name == "target");
            var href = node.Attributes.FirstOrDefault(a => a.Name == "href");

            if (target != null)
            {
                attrs.Target = target.Value;
            }

            if (href != null)
            {
                attrs.Href = href.Value;
            }

            data.Attrs = attrs;

            return data;
        }
    }
}
