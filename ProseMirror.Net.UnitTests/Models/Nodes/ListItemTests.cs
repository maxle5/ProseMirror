using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class ListItemTests
    {
        [Fact]
        public void Type_ShouldReturnListItem()
        {
            // act
            var listItem = new ListItem();

            // assert
            listItem.Type.Should().Be("listItem");
        }
    }
}
