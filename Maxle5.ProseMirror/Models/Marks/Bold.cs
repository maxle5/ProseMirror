using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Bold : MarkDefinition
    {
        public Bold() : base("bold")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<strong></strong>");
        }
    }
}
