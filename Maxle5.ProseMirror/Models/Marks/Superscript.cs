using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Superscript : MarkDefinition
    {
        public Superscript() : base("superscript")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<sup></sup>");
        }
    }
}
