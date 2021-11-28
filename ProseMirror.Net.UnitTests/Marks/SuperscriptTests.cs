using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class SuperscriptTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagSuperscript()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<sup>This should be superscript</sup>");

            // act
            var matches = new Superscript().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotSuperscript()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be superscript</span>");

            // act
            var matches = new Superscript().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnSuperscriptMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<sup>This should be superscript</sup>");

            // act
            var data = new Superscript().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.Type.Should().Be("superscript");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be superscript</span>");

            // act
            var act = () => new Superscript().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
