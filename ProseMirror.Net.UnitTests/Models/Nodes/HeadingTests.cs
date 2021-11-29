using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class HeadingTests
    {
        [Fact]
        public void Type_ShouldReturnHeading()
        {
            // arrange
            const string html = "<h1>this is some text</h1>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var heading = new Heading(node);

            // assert
            heading.Type.Should().Be("heading");
        }
    }
}
