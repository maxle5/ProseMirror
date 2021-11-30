using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
