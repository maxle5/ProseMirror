using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class BoldTests
    {
        [Theory]
        [InlineData("b")]
        [InlineData("strong")]
        public void Matches_ShouldReturnTrue_WhenHtmlTagBold(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should be bold</{tagName}>");

            // act
            var matches = new Bold().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Theory]
        [InlineData("p")]
        [InlineData("em")]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotBold(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should NOT be bold</{tagName}>");

            // act
            var matches = new Bold().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnBoldMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<strong>This should be bold</strong>");

            // act
            var data = new Bold().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.MarkType.Bold);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be bold</span>");

            // act
            Func<Model.Marks> act = () => new Bold().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
