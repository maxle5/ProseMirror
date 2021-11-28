using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class CodeTests
    {
        [Theory]
        [InlineData("div", "code")]
        [InlineData("section", "code")]
        public void Matches_ShouldReturnTrue_WhenHtmlTagCode(string parentTagName, string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{parentTagName}><{tagName}>This should be bold</{tagName}></{parentTagName}>");

            // act
            var matches = new Code().Matches(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Theory]
        [InlineData("pre", "code")]
        [InlineData("div", "span")]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotCode(string parentTagName, string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{parentTagName}><{tagName}>This should be code</{tagName}></{parentTagName}>");

            // act
            var matches = new Code().Matches(doc.DocumentNode.ChildNodes[0].ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnCodeMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<code>This should be bold</code>");

            // act
            var data = new Code().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.MarkType.Code);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be bold</span>");

            // act
            Func<Model.Marks> act = () => new Code().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
