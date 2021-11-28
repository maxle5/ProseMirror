using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class BlockquoteTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagBlockquote()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<blockquote>This should be blockquote</blockquote>");

            // act
            var matches = new Blockquote().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotBlockquote()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<span>This should NOT be blockquote</span>");

            // act
            var matches = new Blockquote().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnBlockquoteMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<blockquote>This should be blockquote</blockquote>");

            // act
            var data = new Blockquote().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.Blockquote);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be blockquote</span>");

            // act
            var act = () => new Blockquote().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
