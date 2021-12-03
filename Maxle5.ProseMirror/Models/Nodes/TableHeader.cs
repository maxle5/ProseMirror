using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class TableHeader : TableCell
    {
        public TableHeader(HtmlNode node) : base(node, "tableHeader")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            var tag = base.RenderHtmlNode();
            tag.Name = "th";

            return tag;
        }
    }
}
