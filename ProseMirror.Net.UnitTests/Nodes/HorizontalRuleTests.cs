using FluentAssertions;
using HtmlAgilityPack;
using ProseMirror.Net.Nodes;
using System;
using Xunit;

namespace ProseMirror.Net.UnitTests.Nodes
{
    public class HorizontalRuleTests
    {
        [Fact]
        public void Matches_ShouldReturnTrue_WhenHtmlTagHr()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<hr>");

            // act
            var matches = new HorizontalRule().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeTrue();
        }

        [Fact]
        public void Matches_ShouldReturnFalse_WhenHtmlTagNotHr()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should NOT be horizontal rule</span>");

            // act
            var matches = new HorizontalRule().Matches(doc.DocumentNode.ChildNodes[0]);

            // assert
            matches.Should().BeFalse();
        }

        [Fact]
        public void Data_ShouldReturnHorizontalRuleMark_WhenValidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<hr>");

            // act
            var data = new HorizontalRule().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            data.TypeEnum.Should().Be(Model.NodeType.HorizontalRule);
        }

        [Fact]
        public void Data_ShouldThrow_WhenInvalidNode()
        {
            // arrange
            var doc = new HtmlDocument();
            doc.LoadHtml("<span>This should be horizontal rule</span>");

            // act
            var act = () => new HorizontalRule().Data(doc.DocumentNode.ChildNodes[0]);

            // assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
