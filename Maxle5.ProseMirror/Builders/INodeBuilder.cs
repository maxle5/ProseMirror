using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Builders
{
    public interface INodeBuilder
    {
        bool AppliesToHtmlNode(HtmlNode htmlNode);
        Node BuildNode(HtmlNode htmlNode);
    }
}
