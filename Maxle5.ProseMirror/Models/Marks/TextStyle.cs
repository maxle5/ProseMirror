using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using System.Linq;

namespace Maxle5.ProseMirror.Models.Marks
{
    internal class TextStyleAttributes : MarkAttributes
    {
        public string Color { get; set; }
    }

    internal class TextStyle : MarkDefinition
    {
        public TextStyle(HtmlNode node) : base("textStyle")
        {
            Attrs = GetAttrs(node);
        }

        public static TextStyleAttributes GetAttrs(HtmlNode node)
        {
            TextStyleAttributes attributes = null;
            var styleAttribute = node.Attributes.FirstOrDefault(a => a.Name == "style");

            if (styleAttribute != null)
            {
                foreach (var style in styleAttribute.Value.Split(';').Select(style => style.Replace(" ", "")))
                {
                    const string color = "color:";
                    if (style.StartsWith(color))
                    {
                        if (attributes == null)
                        {
                            attributes = new TextStyleAttributes();
                        }

                        attributes.Color = style.Substring(color.Length);
                    }
                }
            }

            return attributes;
        }
    }
}