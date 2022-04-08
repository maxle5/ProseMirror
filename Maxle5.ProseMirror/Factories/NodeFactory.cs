using HtmlAgilityPack;
using Maxle5.ProseMirror.Builders;
using Maxle5.ProseMirror.Models;
using System.Collections.Generic;
using System.Linq;

namespace Maxle5.ProseMirror.Factories
{
    internal static class NodeFactory
    {
        private static readonly IEnumerable<INodeBuilder> _defaultNodeBuilders = new INodeBuilder[]
        {
            new BlockQuoteNodeBuilder(),
            new BulletListNodeBuilder(),
            new CodeBlockNodeBuilder(),
            new HardBreakNodeBuilder(),
            new HeadingNodeBuilder(),
            new HorizontalRuleNodeBuilder(),
            new ImageNodeBuilder(),
            new ListItemNodeBuidler(),
            new OrderedListNodeBuilder(),
            new ParagraphNodeBuilder(),
            new TableNodeBuilder(),
            new TableCellNodeBuilder(),
            new TableHeaderNodeBuilder(),
            new TableRowNodeBuilder(),
            new TextNodeBuilder(),
        };

        public static Node Get(HtmlNode htmlNode, IEnumerable<INodeBuilder> customNodeBuilders = null)
        {
            customNodeBuilders ??= Enumerable.Empty<INodeBuilder>();
            var nodeBuilders = customNodeBuilders.Concat(_defaultNodeBuilders);
            var noteBuilder = nodeBuilders.FirstOrDefault(builder => builder.AppliesToHtmlNode(htmlNode));

            if (noteBuilder != null)
            {
                return noteBuilder.BuildNode(htmlNode);
            }

            return null;
        }
    }
}
