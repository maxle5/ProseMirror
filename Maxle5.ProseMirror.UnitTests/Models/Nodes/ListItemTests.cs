using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
