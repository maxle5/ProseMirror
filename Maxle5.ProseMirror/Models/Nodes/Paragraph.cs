using HtmlAgilityPack;
using System.Linq;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class ParagraphAttributes : NodeAttributes
    {
        public string TextAlign { get; set; } = "left";
    }

    internal class Paragraph : NodeDefinition
    {
        public Paragraph(HtmlNode node) : base("paragraph")
        {
            Attrs = GetAttrs(node);
        }

        private static ParagraphAttributes GetAttrs(HtmlNode node)
        {
            var attributes = new ParagraphAttributes();
            var styleAttribute = node.Attributes.FirstOrDefault(a => a.Name == "style");

            if (styleAttribute != null)
            {
                foreach (var style in styleAttribute.Value.Split(';'))
                {
                    const string textAlign = "text-align:";
                    if (style.Replace(" ", "").StartsWith(textAlign))
                    {
                        if (attributes == null)
                        {
                            attributes = new ParagraphAttributes();
                        }

                        attributes.TextAlign = style.Substring(textAlign.Length + 1);
                    }
                }
            }

            return attributes;
        }
    }
}