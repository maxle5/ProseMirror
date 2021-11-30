using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class TableTests
    {
        [Fact]
        public void Type_ShouldReturnTable()
        {
            // act
            var table = new Table();

            // assert
            table.Type.Should().Be("table");
        }
    }
}
