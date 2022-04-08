using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Factories;
using Maxle5.ProseMirror.Models.Nodes;
using System;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Services
{
    public class NodeDefinitionFactoryTests
    {
        [Theory]
        [InlineData("blockquote", typeof(Blockquote))]
        [InlineData("ul", typeof(BulletList))]
        [InlineData("br", typeof(HardBreak))]
        [InlineData("h1", typeof(Heading))]
        [InlineData("h2", typeof(Heading))]
        [InlineData("h3", typeof(Heading))]
        [InlineData("h4", typeof(Heading))]
        [InlineData("h5", typeof(Heading))]
        [InlineData("h6", typeof(Heading))]
        [InlineData("hr", typeof(HorizontalRule))]
        [InlineData("img", typeof(Image))]
        [InlineData("li", typeof(ListItem))]
        [InlineData("ol", typeof(OrderedList))]
        [InlineData("p", typeof(Paragraph))]
        [InlineData("td", typeof(TableCell))]
        [InlineData("th", typeof(TableHeader))]
        [InlineData("tr", typeof(TableRow))]
        [InlineData("#text", typeof(TextNode))]
        public void Get_ShouldReturnCorrectNode_WhenTagMatches(string tag, Type type)
        {
            // arrange
            var html = $"<{tag}>this is some text</{tag}>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var mark = NodeFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            mark.Should().NotBeNull();
            mark.Should().BeOfType(type);
        }

        [Fact]
        public void Get_ShouldReturnTable_WhenTagTbodyAndParentTagTable()
        {
            // arrange
            const string html = "<table><tbody>this is some text</tbody></table>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var node = NodeFactory.Get(document.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            node.Should().NotBeNull();
            node.Should().BeOfType<Table>();
        }

        [Fact]
        public void Get_ShouldReturnTable_WhenTagTableAndNoTBodyTags()
        {
            // arrange
            const string html = "<table><tr><td>this is some text<td></tr></table>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var node = NodeFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            node.Should().NotBeNull();
            node.Should().BeOfType<Table>();
        }

        [Fact]
        public void Get_ShouldReturnCodeBlock_WhenTagCodeAndParentParentTagPre()
        {
            // arrange
            const string html = "<pre><code>this is some text</code></pre>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var node = NodeFactory.Get(document.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            node.Should().NotBeNull();
            node.Should().BeOfType<CodeBlock>();
        }

        [Fact]
        public void Get_ShouldReturnNull_WhenTagUnsupported()
        {
            // arrange
            const string html = "<tag>this is some text</tag>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var node = NodeFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            node.Should().BeNull();
        }
    }
}
