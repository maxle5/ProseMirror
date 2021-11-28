using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class TableTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagTable()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<table><tbody><tr><td></td></tr></tbody></table>");

            // act
            var matches = new Table().Matches(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotTable()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be table</span>");

            // act
            var matches = new Table().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnTableMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<table><tbody><tr><td></td></tr></tbody></table>");

            // act
            var data = new Table().Data(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            data.Type.Should().Be("table");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be table</span>");

            // act
            Func<Model.Node> act = () => new Table().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
