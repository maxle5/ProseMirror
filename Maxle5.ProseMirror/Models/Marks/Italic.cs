using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Italic : Mark
    {
        public Italic() : base("italic")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<em></em>");
        }
    }
}
