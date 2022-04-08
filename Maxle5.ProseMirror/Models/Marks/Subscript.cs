using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Subscript : Mark
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
