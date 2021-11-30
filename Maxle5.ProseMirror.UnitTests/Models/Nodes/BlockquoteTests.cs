using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class BlockquoteTests
    {
        [Fact]
        public void Type_ShouldReturnBlockquote()
        {
            // act
            var blockquote = new Blockquote();

            // assert
            blockquote.Type.Should().Be("blockquote");
        }
    }
}
