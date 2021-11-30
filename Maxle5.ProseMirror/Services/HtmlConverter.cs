using HtmlAgilityPack;
using Maxle5.ProseMirror.Models;
using Maxle5.ProseMirror.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maxle5.ProseMirror.Services
{
    public class HtmlConverter
    {
        private readonly HtmlDocument _document = new HtmlDocument();
        private readonly List<MarkDefinition> _storedMarks = new List<MarkDefinition>();

        internal HtmlConverter()
        {
        }

        public string Convert(NodeDefinition node)
        {
            throw new NotImplementedException();
        }

        public NodeDefinition Convert(string html)
        {
            _document.LoadHtml(html);

            return new Document
            {
                Content = RenderChildren(GetDocumentBody()).ToArray()
            };
        }

        private HtmlNode GetDocumentBody()
        {
            return _document.DocumentNode.Descendants("body").FirstOrDefault();
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
    }
}
