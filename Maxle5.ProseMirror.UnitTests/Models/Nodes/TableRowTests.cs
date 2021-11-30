using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
