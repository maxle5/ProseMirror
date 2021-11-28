using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class TableCellTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagTd()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<td>This should be table cell</td>");

            // act
            var matches = new TableCell().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotTd()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be table cell</span>");

            // act
            var matches = new TableCell().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnTableCellMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<td>This should be table cell</td>");

            // act
            var data = new TableCell().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.Type.Should().Be("table_cell");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be table cell</span>");

            // act
            var act = () => new TableCell().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
