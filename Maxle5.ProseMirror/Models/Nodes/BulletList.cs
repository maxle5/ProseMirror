using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class BulletList : NodeDefinition
    {
        public BulletList() : base("bulletList")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<ul></ul>");
        }
    }
}