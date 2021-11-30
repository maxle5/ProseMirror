using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Marks;
using Maxle5.ProseMirror.Services;
using System;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Services
{
    public class MarkDefinitionFactoryTests
    {
        [Theory]
        [InlineData("b", typeof(Bold))]
        [InlineData("strong", typeof(Bold))]
        [InlineData("code", typeof(Code))]
        [InlineData("em", typeof(Italic))]
        [InlineData("i", typeof(Italic))]
        [InlineData("a", typeof(Link))]
        [InlineData("strike", typeof(Strike))]
        [InlineData("s", typeof(Strike))]
        [InlineData("del", typeof(Strike))]
        [InlineData("sub", typeof(Subscript))]
        [InlineData("sup", typeof(Superscript))]
        [InlineData("u", typeof(Underline))]
        public void Get_ShouldReturnCorrectMark_WhenTagMatches(string tag, Type type)
        {
            // arrange
            var html = $"<{tag}>this is some text</{tag}>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var mark = MarkDefinitionFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            mark.Should().NotBeNull();
            mark.Should().BeOfType(type);
        }

        [Fact]
        public void Get_ShouldReturnTextStyle_WhenStyleAttributePresent()
        {
            // arrange
            const string html = "<span style='color: red'>this is some text</span>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var mark = MarkDefinitionFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            mark.Should().NotBeNull();
            mark.Should().BeOfType<TextStyle>();
        }

        [Fact]
        public void Get_ShouldReturnNull_WhenUnsupportedTag()
        {
            // arrange
            const string html = "<tag>this should be bold</tag>";
            var document = new HtmlDocument();
            document.LoadHtml(html);

            // act
            var mark = MarkDefinitionFactory.Get(document.DocumentNode.ChildNodes[0]);

            // assert
            mark.Should().BeNull();
        }
    }
}
