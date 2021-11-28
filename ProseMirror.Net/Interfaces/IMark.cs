using HtmlAgilityPack;

namespace ProseMirror.Net.Interfaces
{
    internal interface IMark
    {
        bool Matches(HtmlNode node);
        Model.Marks Data(HtmlNode node);
    }
}