using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class OrderedListTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagOl()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<ol>This should be ordered list</ol>");

            // act
            var matches = new OrderedList().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotOl()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be ordered list</span>");

            // act
            var matches = new OrderedList().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnOrderedListMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<ol>This should be ordered list</ol>");

            // act
            var data = new OrderedList().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.OrderedList);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be ordered list</span>");

            // act
            var act = () => new OrderedList().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
