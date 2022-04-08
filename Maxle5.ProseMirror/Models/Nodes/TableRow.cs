using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class TableRow : Node
    {
        public TableRow() : base("tableRow")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<tr></tr>");
        }
    }
}
