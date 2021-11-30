using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using System.Linq;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class LinkAttributes : MarkAttributes
    {
        public string Target { get; set; }
        public string Href { get; set; }
    }

    internal class Link : MarkDefinition
    {
        public Link(HtmlNode node) : base("link")
        {
            Attrs = new LinkAttributes
            {
                Target = node.Attributes.FirstOrDefault(a => a.Name == "target")?.Value,
                Href = node.Attributes.FirstOrDefault(a => a.Name == "href")?.Value
            };
        }
    }
}