using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Services
{
    internal static class NodeDefinitionFactory
    {
        public static NodeDefinition Get(HtmlNode htmlNode)
        {
            if (htmlNode.Name == "blockquote")
            {
                return new Blockquote();
            }
            else if (htmlNode.Name == "ul")
            {
                return new BulletList();
            }
            else if (htmlNode.Name == "code" && htmlNode.ParentNode.Name == "pre")
            {
                return new CodeBlock();
            }
            else if (htmlNode.Name == "br")
            {
                return new HardBreak();
            }
            else if (htmlNode.Name == "h1" || htmlNode.Name == "h2" || htmlNode.Name == "h3" || htmlNode.Name == "h4" || htmlNode.Name == "h5" || htmlNode.Name == "h6")
            {
                return new Heading(htmlNode);
            }
            else if (htmlNode.Name == "hr")
            {
                return new HorizontalRule();
            }
            else if (htmlNode.Name == "img")
            {
                return new Image(htmlNode);
            }
            else if (htmlNode.Name == "li")
            {
                return new ListItem();
            }
            else if (htmlNode.Name == "ol")
            {
                return new OrderedList();
            }
            else if (htmlNode.Name == "p")
            {
                return new Paragraph(htmlNode);
            }
            else if (htmlNode.Name == "tbody" && htmlNode.ParentNode.Name == "table")
            {
                return new Table();
            }
            else if (htmlNode.Name == "td")
            {
                return new TableCell(htmlNode);
            }
            else if (htmlNode.Name == "th")
            {
                return new TableHeader(htmlNode);
            }
            else if (htmlNode.Name == "tr")
            {
                return new TableRow();
            }
            else if (htmlNode.Name == "#text")
            {
                return new TextNode(htmlNode);
            }

            return null;
        }
    }
}
