using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class BulletList : Node
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