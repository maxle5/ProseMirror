using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;
using System.Linq;

namespace ProseMirror.Net.Nodes
{
    internal class TableCellAttributes
    {
        public int ColSpan { get; set; }
        public int[] ColWidth { get; set; }
        public int RowSpan { get; set; }
    }

    internal class TableCellNode : CustomNode
    {
        public TableCellAttributes Attrs { get; set; }
    }

    internal class TableCell : INode
    {
        public bool Matches(HtmlNode node)
        {
            return node.Name == "td";
        }

        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            var data = new TableCellNode
            {
                Type = "table_cell",
            };
            var attrs = new TableCellAttributes();
            var colspan = node.Attributes.FirstOrDefault(a => a.Name == "colspan");
            var colwidth = node.Attributes.FirstOrDefault(a => a.Name == "data-colwidth");
            var rowspan = node.Attributes.FirstOrDefault(a => a.Name == "rowspan");

            if (colspan != null)
            {
                attrs.ColSpan = Convert.ToInt32(colspan.Value);
            }
            if (colwidth != null)
            {
                var widths = colwidth.Value.Split(',');

                if (widths.Length == attrs.ColSpan)
                {
                    attrs.ColWidth = widths.Select(str => Convert.ToInt32(str)).ToArray();
                }
            }
            if (rowspan != null)
            {
                attrs.RowSpan = Convert.ToInt32(rowspan.Value);
            }

            if (attrs != default)
            {
                data.Attrs = attrs;
            }

            return data;
        }
    }
}
