using HtmlAgilityPack;

namespace ProseMirror.Net.Models.Nodes
{
    internal class TableHeader : TableCell
    {
        public TableHeader(HtmlNode node) : base(node, "tableHeader")
        {
        }
    }
}
