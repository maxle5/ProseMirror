using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class ItalicTests
    {
        [Theory]
        [InlineData("i")]
        [InlineData("em")]
        public void Matches_ShouldReturnTrue_WhenHtmlTagItalic(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should be italic</{tagName}>");

            // act
            var matches = new Italic().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Theory]
        [InlineData("pre")]
        [InlineData("div")]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotItalic(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should be italic</{tagName}>");

            // act
            var matches = new Italic().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnCodeMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<em>This should be bold</em>");

            // act
            var data = new Italic().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.MarkType.Italic);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be bold</span>");

            // act
            Func<Model.Marks> act = () => new Italic().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
