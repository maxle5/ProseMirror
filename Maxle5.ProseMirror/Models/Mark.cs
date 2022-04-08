using HtmlAgilityPack;

namespace Maxle5.ProseMirror.Models
{
    public abstract class MarkAttributes
    {
    }

    public abstract class Mark
    {
        public string Type { get; }
        public MarkAttributes Attrs { get; set; }

        protected Mark(string type)
        {
            Type = type;
        }

        public abstract HtmlNode RenderHtmlNode();
    }
}