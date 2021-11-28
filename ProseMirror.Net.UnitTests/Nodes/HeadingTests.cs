using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class HeadingTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagH1()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<h1>This should be heading</h1>");

            // act
            var matches = new Heading().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagH2()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<h2>This should be heading</h2>");

            // act
            var matches = new Heading().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagH3()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<h3>This should be heading</h3>");

            // act
            var matches = new Heading().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagH4()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<h4>This should be heading</h4>");

            // act
            var matches = new Heading().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagH5()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<h5>This should be heading</h5>");

            // act
            var matches = new Heading().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }
    }
}
