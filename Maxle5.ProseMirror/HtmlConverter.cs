using HtmlAgilityPack;
using Maxle5.ProseMirror.Builders;
using Maxle5.ProseMirror.Factories;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maxle5.ProseMirror
{
    internal class HtmlConverter
    {
        private readonly HtmlDocument _document = new HtmlDocument();
        private readonly List<Mark> _storedMarks = new List<Mark>();
        private readonly IEnumerable<INodeBuilder> _customNodeBuilders;

        public HtmlConverter(IEnumerable<INodeBuilder> customNodeBuilders = null)
        {
            _customNodeBuilders = customNodeBuilders ?? Enumerable.Empty<INodeBuilder>();
        }

        public string Convert(Node node)
        {
            return RenderChildren(node).OuterHtml;
        }

        public Node Convert(string html)
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

        private HtmlNode RenderChildren(Node node)
        {
            var tag = ConvertNodeToHtmlNode(node);

            foreach (var child in node?.Content ?? Enumerable.Empty<Node>())
            {
                tag.AppendChild(RenderChildren(child));
            }

            return tag.ParentNode ?? tag;
        }

        private IEnumerable<Node> RenderChildren(HtmlNode htmlNode)
        {
            var nodes = new List<Node>();

            foreach (var child in htmlNode.ChildNodes)
            {
                var item = NodeFactory.Get(child, _customNodeBuilders);
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
                    var mark = MarkFactory.Get(child);
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

        private HtmlNode ConvertNodeToHtmlNode(Node node)
        {
            return WithMarks(node, node.RenderHtmlNode());
        }

        private static HtmlNode WithMarks(Node node, HtmlNode htmlNode)
        {
            var resultNode = htmlNode;
            foreach (var mark in node.Marks?.Reverse() ?? Array.Empty<Mark>())
            {
                var markHtmlNode = mark.RenderHtmlNode();
                resultNode = markHtmlNode.AppendChild(resultNode).ParentNode;
            }

            return resultNode;
        }
    }
}
