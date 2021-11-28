using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class SubscriptTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagSubscript()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<sub>This should be subscript</sub>");

            // act
            var matches = new Subscript().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotSubscript()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be subscript</span>");

            // act
            var matches = new Subscript().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnSubscriptMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<sub>This should be subscript</sub>");

            // act
            var data = new Subscript().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.Type.Should().Be("subscript");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be subscript</span>");

            // act
            var act = () => new Subscript().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
