using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
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
