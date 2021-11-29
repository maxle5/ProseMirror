using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
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
