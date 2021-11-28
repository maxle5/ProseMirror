using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class TextTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagText()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("This should be text");

            // act
            var matches = new Text().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotText()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be text</span>");

            // act
            var matches = new Text().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnTextMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("This should be text");

            // act
            var data = new Text().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.Text);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be text</span>");

            // act
            var act = () => new Text().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
