using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Italic : MarkDefinition
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
