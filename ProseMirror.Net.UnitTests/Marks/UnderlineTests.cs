using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class UnderlineTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagUnderline()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<u>This should be underline</u>");

            // act
            var matches = new Underline().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotUnderline()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be underline</span>");

            // act
            var matches = new Underline().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnUnderlineMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<u>This should be underline</u>");

            // act
            var data = new Underline().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.Type.Should().Be("underline");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be underline</span>");

            // act
            var act = () => new Underline().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
