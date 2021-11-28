using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using System;

namespace ProseMirror.Net.Nodes
{
    internal class CodeBlock : INode
    {
        public Node Data(HtmlNode node)
        {
            if (!Matches(node))
            {
                throw new InvalidOperationException();
            }

            return new StandardNode()
            {
                TypeEnum = NodeType.CodeBlock,
            };
        }

        public bool Matches(HtmlNode node)
        {
            return node.Name == "code" &&
                   node.ParentNode.Name == "pre";
        }
    }
}
