using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class TextStyleTests
    {
        [Fact]
        public void Type_ShouldReturnTextStyle()
        {
            // arrange
            const string html = "<span style='color: red'>this is some text</span>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var subscript = new TextStyle(node);

            // assert
            subscript.Type.Should().Be("textStyle");
        }

        [Fact]
        public void Attrs_ShouldIncludeColor_WhenHtmlStyleAttributePresentWithColorProperty()
        {
            // arrange
            const string color = "red";
            var html = $"<span style='color: {color}'>this is some text</span>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var textStyle = new TextStyle(node);

            // assert
            textStyle.Attrs.Should().BeOfType<TextStyleAttributes>().Which.Color.Should().Be(color);
        }
    }
}
