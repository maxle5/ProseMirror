using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
