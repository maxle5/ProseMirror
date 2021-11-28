using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class HardBreakTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagBr()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<br>");

            // act
            var matches = new HardBreak().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotBr()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be hard break</span>");

            // act
            var matches = new HardBreak().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnHardBreakMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<br>");

            // act
            var data = new HardBreak().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.HardBreak);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be hard break</span>");

            // act
            var act = () => new HardBreak().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
