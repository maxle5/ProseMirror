using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class OrderedListAttributes : NodeAttributes
    {
        public int Start { get; set; } = 1;
    }

    internal class OrderedList : Node
    {
        public OrderedList() : base("orderedList")
        {
            Attrs = new OrderedListAttributes();
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<ol></ol>");
        }
    }
}
