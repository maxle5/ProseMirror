using HtmlAgilityPack;

namespace ProseMirror.Net.Models.Nodes
{
    internal class TextNode : NodeDefinition
    {
        public string Text { get; set; }

        public TextNode(HtmlNode node) : base("text")
        {
            Text = node.InnerText.TrimStart('\n');
        }
    }
}