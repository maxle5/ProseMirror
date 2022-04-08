﻿using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;

namespace Maxle5.ProseMirror.Builders
{
    internal class TableRowNodeBuilder : INodeBuilder
    {
        public bool AppliesToHtmlNode(HtmlNode htmlNode)
        {
            return htmlNode.Name == "tr";
        }

        public Node BuildNode(HtmlNode htmlNode)
        {
            return new TableRow();
        }
    }
}
