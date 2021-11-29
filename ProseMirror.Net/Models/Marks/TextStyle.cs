using HtmlAgilityPack;
using System.Linq;

namespace ProseMirror.Net.Models.Marks
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
                foreach (var style in styleAttribute.Value.Split(';'))
                {
                    const string color = "color:";
                    if (style.Replace(" ", "").StartsWith(color))
                    {
                        if (attributes == null)
                        {
                            attributes = new TextStyleAttributes();
                        }

                        attributes.Color = style.Substring(color.Length + 1);
                    }
                }
            }

            return attributes;
        }
    }
}