using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class StrikeTests
    {
        [Theory]
        [InlineData("s")]
        [InlineData("del")]
        [InlineData("strike")]
        public void Matches_ShouldReturnTrue_WhenHtmlTagStrike(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should be strike</{tagName}>");

            // act
            var matches = new Strike().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Theory]
        [InlineData("p")]
        [InlineData("em")]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotStrike(string tagName)
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml($"<{tagName}>This should NOT be strike</{tagName}>");

            // act
            var matches = new Strike().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnStrikeMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<s>This should be strike</s>");

            // act
            var data = new Strike().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.MarkType.Strike);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be strike</span>");

            // act
            var act = () => new Strike().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
