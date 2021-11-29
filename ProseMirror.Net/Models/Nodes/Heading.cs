using HtmlAgilityPack;
using System;
using System.Text.RegularExpressions;

namespace ProseMirror.Net.Models.Nodes
{
    internal class HeadingAttributes : NodeAttributes
    {
        public int? Level { get; set; }
        public string TextAlign { get; set; } = "left";
    }

    internal class Heading : NodeDefinition
    {
        public Heading(HtmlNode node) : base("heading")
        {
            Attrs = new HeadingAttributes
            {
                Level = GetLevel(node.Name)
            };
        }

        public static int? GetLevel(string tagName)
        {
            var match = Regex.Match(tagName, "^h([1-6])$");
            return match.Success ? (int?)Convert.ToInt32(match.Groups[1].Value) : null;
        }
    }
}
