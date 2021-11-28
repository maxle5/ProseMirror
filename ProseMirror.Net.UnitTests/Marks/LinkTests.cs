using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Marks;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Marks
{
    public class LinkTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagLink()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<a href='http://www.google.com'>This should be link</a>");

            // act
            var matches = new Link().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotLink()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be link</span>");

            // act
            var matches = new Link().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnLinkMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<a href='http://www.google.com'>This should be link</a>");

            // act
            var data = new Link().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.MarkType.Link);
            data.Attrs.Href.Should().Be("http://www.google.com");
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be link</span>");

            // act
            Func<Model.Marks> act = () => new Link().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
