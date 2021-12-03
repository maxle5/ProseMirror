using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Subscript : MarkDefinition
    {
        public Subscript() : base("subscript")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<sub></sub>");
        }
    }
}
