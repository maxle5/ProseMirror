using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class OrderedListTests
    {
        [Fact]
        public void Type_ShouldReturnOrderedList()
        {
            // act
            var orderedList = new OrderedList();

            // assert
            orderedList.Type.Should().Be("orderedList");
        }
    }
}
