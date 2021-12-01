using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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

        [Theory]
        [InlineData("<p style='text-align:center;text-indent:0;'>centered text</p>", "center")]
        [InlineData("<p style='text-align: right;text-indent:0;'>centered text</p>", "right")]
        [InlineData("<p style='text-indent:0;text-align: left;'>centered text</p>", "left")]
        public void Attrs_ShouldIncludeTextAlign_WhenHtmlStyleAttributePresentWithTextProperty(string html, string textAlign)
        {
            // arrange
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var paragraph = new Paragraph(node);

            // assert
            paragraph.Attrs.Should().BeOfType<ParagraphAttributes>().Which.TextAlign.Should().Be(textAlign);
        }
    }
}
