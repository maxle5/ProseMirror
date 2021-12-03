using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Marks;
using Maxle5.ProseMirror.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maxle5.ProseMirror.Services
{
    internal class HtmlConverter
    {
        private readonly HtmlDocument _document = new HtmlDocument();
        private readonly List<MarkDefinition> _storedMarks = new List<MarkDefinition>();

        public string Convert(NodeDefinition node)
        {
            return RenderChildren(node).OuterHtml;
        }

        public NodeDefinition Convert(string html)
        {
            _document.LoadHtml(html);

            return new Document
            {
                Content = RenderChildren(GetRootNode()).ToArray()
            };
        }

        private HtmlNode GetRootNode()
        {
            var bodyNode = _document.DocumentNode.Descendants("body").FirstOrDefault();
            return bodyNode ?? _document.DocumentNode; // return first node if <body> does not exist
        }

        private HtmlNode RenderChildren(NodeDefinition node)
        {
            var tag = ConvertNodeToHtmlNode(node);

            foreach (var child in node?.Content ?? Enumerable.Empty<NodeDefinition>())
            {
                tag.AppendChild(RenderChildren(child));
            }

            return tag.ParentNode ?? tag;
        }

        private IEnumerable<NodeDefinition> RenderChildren(HtmlNode htmlNode)
        {
            var nodes = new List<NodeDefinition>();

            foreach (var child in htmlNode.ChildNodes)
            {
                var item = NodeDefinitionFactory.Get(child);
                if (item != null)
                {
                    if (item == null)
                    {
                        if (child.HasChildNodes)
                        {
                            nodes.AddRange(RenderChildren(child));
                        }

                        continue;
                    }

                    if (child.HasChildNodes)
                    {
                        item.Content = RenderChildren(child).ToArray();
                    }

                    if (_storedMarks.Count > 0)
                    {
                        item.Marks = _storedMarks.ToArray();
                    }

                    nodes.Add(item);
                }
                else
                {
                    var mark = MarkDefinitionFactory.Get(child);
                    if (mark != null)
                    {
                        _storedMarks.Add(mark);

                        if (child.HasChildNodes)
                        {
                            nodes.AddRange(RenderChildren(child));
                        }

                        if (_storedMarks.Count > 0)
                        {
                            _storedMarks.RemoveAt(_storedMarks.Count - 1);
                        }
                    }
                    else if (child.HasChildNodes)
                    {
                        nodes.AddRange(RenderChildren(child));
                    }
                }
            }

            return nodes;
        }

        private HtmlNode ConvertNodeToHtmlNode(NodeDefinition node)
        {
            return WithMarks(node, node.RenderHtmlNode());
        }

        private static HtmlNode WithMarks(NodeDefinition node, HtmlNode htmlNode)
        {
            HtmlNode resultNode = htmlNode;
            foreach(var mark in node.Marks?.Reverse() ?? Array.Empty<MarkDefinition>())
            {
                var markHtmlNode = mark.RenderHtmlNode();
                resultNode = markHtmlNode.AppendChild(resultNode).ParentNode;
            }

            return resultNode;
        }
    }
}
