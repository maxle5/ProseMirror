using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class CodeBlockTests
    {
        [Fact]
        public void Type_ShouldReturnCodeBlock()
        {
            // act
            var codeBlock = new CodeBlock();

            // assert
            codeBlock.Type.Should().Be("codeBlock");
        }
    }
}
