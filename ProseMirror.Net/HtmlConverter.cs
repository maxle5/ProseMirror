using HtmlAgilityPack;
using ProseMirror.Model;
using ProseMirror.Net.Interfaces;
using ProseMirror.Net.Marks;
using ProseMirror.Net.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace ProseMirror.Net
{
    public class HtmlConverter
    {
        private readonly HtmlDocument _document = new();
        private readonly List<Model.Marks> _storedMarks = new();

        private readonly IEnumerable<INode> _nodes = new List<INode>
        {
            new Blockquote(),
            new BulletList(),
            new CodeBlock(),
            new CodeBlockWrapper(),
            new HardBreak(),
            new Heading(),
            new HorizontalRule(),
            new Image(),
            new ListItem(),
            new OrderedList(),
            new Paragraph(),
            new Table(),
            new TableCell(),
            new Text()
        };

        private readonly IEnumerable<IMark> _marks = new List<IMark>
        {
            new Bold(),
            new Code(),
            new Italic(),
            new Link(),
            new Strike(),
            new Subscript(),
            new Superscript(),
            new Underline(),
        };

        internal HtmlConverter()
        {
        }

        public Node Convert(string html)
        {
            _document.LoadHtml(html);

            return new StandardNode
            {
                Type = "doc",
                Content = RenderChildren(GetDocumentBody()).ToArray()
            };
        }

        private HtmlNode GetDocumentBody()
        {
            return _document.DocumentNode.Descendants("body").FirstOrDefault();
        }

        private IEnumerable<Node> RenderChildren(HtmlNode htmlNode)
        {
            var nodes = new List<Node>();

            foreach (var child in htmlNode.ChildNodes)
            {
                var childNode = GetMatchingNode(child);
                if (childNode != null)
                {
                    var item = childNode.Data(child);

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

                    if (_storedMarks.Count > 0 && item is StandardNode standardNode)
                    {
                        standardNode.Marks = _storedMarks.ToArray();
                    }

                    //if ($class->wrapper) {
                    //    $item['content'] = [
                    //        array_merge($class->wrapper, [
                    //            'content' => @$item['content'] ?: [],
                    //        ]),
                    //    ];
                    //}

                    nodes.Add(item);
                }
                else
                {
                    var mark = GetMatchingMark(child);
                    if (mark != null)
                    {
                        _storedMarks.Add(mark.Data(child));

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

        private INode GetMatchingNode(HtmlNode item)
        {
            return _nodes.FirstOrDefault(node => node.Matches(item));
        }

        private IMark GetMatchingMark(HtmlNode item)
        {
            return _marks.FirstOrDefault(mark => mark.Matches(item));
        }
    }
}
