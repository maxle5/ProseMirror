using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class TextTests
    {
        [Fact]
        public void Type_ShouldReturnText()
        {
            // arrange
            const string html = "<#text>this is some text</#text>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var text = new TextNode(node);

            // assert
            text.Type.Should().Be("text");
        }
    }
}
