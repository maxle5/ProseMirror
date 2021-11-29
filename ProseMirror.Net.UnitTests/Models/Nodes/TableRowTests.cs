using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class TableRowTests
    {
        [Fact]
        public void Type_ShouldReturnTableRow()
        {
            // act
            var tableRow = new TableRow();

            // assert
            tableRow.Type.Should().Be("tableRow");
        }
    }
}
