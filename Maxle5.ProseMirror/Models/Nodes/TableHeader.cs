using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class TableHeader : TableCell
    {
        public TableHeader(HtmlNode node) : base(node, "tableHeader")
        {
        }
    }
}
