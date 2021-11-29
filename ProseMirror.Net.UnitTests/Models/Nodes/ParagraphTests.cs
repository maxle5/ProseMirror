using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class ParagraphTests
    {
        [Fact]
        public void Type_ShouldReturnParagraph()
        {
            // arrange
            const string html = "<p>this is some text</p>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var paragraph = new Paragraph(node);

            // assert
            paragraph.Type.Should().Be("paragraph");
        }
    }
}
