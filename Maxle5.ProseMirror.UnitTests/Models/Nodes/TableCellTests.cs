using FluentAssertions;
using HtmlAgilityPack;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class TableCellTests
    {
        [Fact]
        public void Type_ShouldReturnTableCell()
        {
            // arrange
            const string html = "<td>this is some text</td>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var node = document.DocumentNode.ChildNodes[0];

            // act
            var tableCell = new TableCell(node);

            // assert
            tableCell.Type.Should().Be("tableCell");
        }
    }
}
