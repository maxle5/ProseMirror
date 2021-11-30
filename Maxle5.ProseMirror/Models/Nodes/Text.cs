using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Models.Nodes
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