using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class CodeBlockTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagCode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<pre><code>This should be code block</code></pre>");

            // act
            var matches = new CodeBlock().Matches(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotCode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be code block</span>");

            // act
            var matches = new CodeBlock().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnCodeBlockMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<pre><code>This should be code block</code></pre>");

            // act
            var data = new CodeBlock().Data(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.CodeBlock);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be code block</span>");

            // act
            Func<Model.Node> act = () => new CodeBlock().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
