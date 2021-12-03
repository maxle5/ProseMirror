using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class Strike : MarkDefinition
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