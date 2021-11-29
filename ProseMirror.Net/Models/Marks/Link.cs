using HtmlAgilityPack;
using System.Linq;

namespace ProseMirror.Net.Models.Marks
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