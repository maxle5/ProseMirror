using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
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
