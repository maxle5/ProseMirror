using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class LinkTests
    {
        [Fact]
        public void Type_ShouldReturnLink_WithCorrectAttrs()
        {
            // arrange
            const string html = "<a>this is some text</a>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var link = new Link(node);

            // assert
            link.Type.Should().Be("link");
        }

        [Fact]
        public void Attrs_ShouldIncludeHref_WhenHtmlHrefAttributePresent()
        {
            // arrange
            const string url = "https://www.google.ca";
            var html = $"<a href='{url}'>this is some text</a>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var link = new Link(node);

            // assert
            link.Attrs.Should().BeOfType<LinkAttributes>().Which.Href.Should().Be(url);
        }

        [Fact]
        public void Attrs_ShouldIncludeTarget_WhenHtmlTargetAttributePresent()
        {
            // arrange
            const string target = "_blank";
            var html = $"<a target='{target}'>this is some text</a>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var link = new Link(node);

            // assert
            link.Attrs.Should().BeOfType<LinkAttributes>().Which.Target.Should().Be(target);
        }
    }
}
