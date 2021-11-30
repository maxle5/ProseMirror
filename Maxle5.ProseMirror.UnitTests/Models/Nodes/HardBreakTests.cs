using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
