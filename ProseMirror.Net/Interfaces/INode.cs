using HtmlAgilityPack;
using ProseMirror.Model;

namespace ProseMirror.Net.Interfaces
{
    internal interface INode
    {
        bool Matches(HtmlNode node);
        Node Data(HtmlNode node);
    }
}
