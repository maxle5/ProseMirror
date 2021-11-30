using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using System;
using System.Linq;

namespace Maxle5.ProseMirror.Models.Nodes
{
    internal class TableCellAttributes : NodeAttributes
    {
        public int Colspan { get; set; }
        public int[] Colwidth { get; set; }
        public int Rowspan { get; set; }
    }

    internal class TableCell : NodeDefinition
    {
        public TableCell(HtmlNode node, string type = "tableCell") : base(type)
        {
            Attrs = GetAttrs(node);
        }

        public static TableCellAttributes GetAttrs(HtmlNode node)
        {
            var attrs = new TableCellAttributes();
            var colspan = node.Attributes.FirstOrDefault(a => a.Name == "colspan");
            var colwidth = node.Attributes.FirstOrDefault(a => a.Name == "colwidth");
            var rowspan = node.Attributes.FirstOrDefault(a => a.Name == "rowspan");

            if (colspan != null)
            {
                attrs.Colspan = Convert.ToInt32(colspan.Value);
            }
            if (colwidth != null)
            {
                var widths = colwidth.Value.Split(',');

                if (widths.Length == attrs.Colspan)
                {
                    attrs.Colwidth = widths.Select(str => Convert.ToInt32(str)).ToArray();
                }
            }
            if (rowspan != null)
            {
                attrs.Rowspan = Convert.ToInt32(rowspan.Value);
            }

            return attrs;
        }
    }
}
