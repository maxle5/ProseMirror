using System.Collections.Generic;

namespace ProseMirror.Net.Models
{
    public abstract class NodeAttributes
    {
    }

    public abstract class NodeDefinition
    {
        public string Type { get; }
        public NodeAttributes Attrs { get; protected set; }
        public IEnumerable<NodeDefinition> Content { get; set; }
        public IEnumerable<MarkDefinition> Marks { get; set; }

        protected NodeDefinition(string type)
        {
            Type = type;
        }
    }
}