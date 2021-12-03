using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class ListItem : NodeDefinition
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
