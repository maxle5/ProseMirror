using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class HardBreak : NodeDefinition
    {
        public HardBreak() : base("hardBreak")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<br></br>");
        }
    }
}
