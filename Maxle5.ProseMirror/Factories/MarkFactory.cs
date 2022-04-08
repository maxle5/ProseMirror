using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Marks;
using System.Linq;

namespace Maxle5.ProseMirror.Factories
{
    internal static class MarkFactory
    {
        public static Mark Get(HtmlNode node)
        {
            if (node.Name == "strong" || node.Name == "b")
            {
                return new Bold();
            }
            else if (node.ParentNode.Name != "pre" && node.Name == "code")
            {
                return new Code();
            }
            else if (node.Name == "em" || node.Name == "i")
            {
                return new Italic();
            }
            else if (node.Name == "a")
            {
                return new Link(node);
            }
            else if (node.Name == "strike" || node.Name == "s" || node.Name == "del")
            {
                return new Strike();
            }
            else if (node.Name == "sub")
            {
                return new Subscript();
            }
            else if (node.Name == "sup")
            {
                return new Superscript();
            }
            else if (node.Attributes.Any(a => a.Name == "style") && TextStyle.GetAttrs(node) != null)
            {
                return new TextStyle(node);
            }
            else if (node.Name == "u")
            {
                return new Underline();
            }

            return null;
        }
    }
}