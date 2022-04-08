using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Strike : Mark
    {
        public Strike() : base("strike")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<s></s>");
        }
    }
}