using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class HorizontalRule : NodeDefinition
    {
        public HorizontalRule() : base("horizontalRule")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<hr></hr>");
        }
    }
}