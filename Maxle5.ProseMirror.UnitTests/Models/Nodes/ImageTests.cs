using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class ImageTests
    {
        [Fact]
        public void Type_ShouldReturnImage()
        {
            // arrange
            const string html = "<img>this is some text</img>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var image = new Image(node);

            // assert
            image.Type.Should().Be("image");
        }
    }
}
