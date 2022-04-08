using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class ListItem : Node
    {
        public ListItem() : base("listItem")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<li></li>");
        }
    }
}
