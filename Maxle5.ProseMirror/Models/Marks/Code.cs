using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Code : Mark
    {
        public Code() : base("code")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<pre></pre>");
        }
    }
}
