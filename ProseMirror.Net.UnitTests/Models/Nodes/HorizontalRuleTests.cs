using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class HorizontalRuleTests
    {
        [Fact]
        public void Type_ShouldReturnHorizontalRule()
        {
            // act
            var horizontalRule = new HorizontalRule();

            // assert
            horizontalRule.Type.Should().Be("horizontalRule");
        }
    }
}
