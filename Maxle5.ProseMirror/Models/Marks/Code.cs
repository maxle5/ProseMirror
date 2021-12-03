using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Code : MarkDefinition
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
