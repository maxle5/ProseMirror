namespace ProseMirror.Net.Models
{
    public abstract class MarkAttributes
    {
    }

    public abstract class MarkDefinition
    {
        public string Type { get; }
        public MarkAttributes Attrs { get; set; }

        protected MarkDefinition(string type)
        {
            Type = type;
        }
    }
}