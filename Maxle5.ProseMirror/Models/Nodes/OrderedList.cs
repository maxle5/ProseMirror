using Maxle5.ProseMirror.Models;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class OrderedListAttributes : NodeAttributes
    {
        public int Start { get; set; } = 1;
    }

    internal class OrderedList : NodeDefinition
    {
        public OrderedList() : base("orderedList")
        {
            Attrs = new OrderedListAttributes();
        }
    }
}
