using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Underline : Mark
    {
        public Underline() : base("underline")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<u></u>");
        }
    }
}
