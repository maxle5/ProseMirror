using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class HardBreakTests
    {
        [Fact]
        public void Type_ShouldReturnHardBreak()
        {
            // act
            var hardBreak = new HardBreak();

            // assert
            hardBreak.Type.Should().Be("hardBreak");
        }
    }
}
