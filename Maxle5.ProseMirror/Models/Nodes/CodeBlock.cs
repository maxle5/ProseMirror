using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class CodeBlock : Node
    {
        public CodeBlock() : base("codeBlock")
        {
        }

        public override HtmlNode RenderHtmlNode()
        {
            return HtmlNode.CreateNode("<code></code>");
        }
    }
}
