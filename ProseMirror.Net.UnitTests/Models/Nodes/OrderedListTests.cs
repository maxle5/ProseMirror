using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
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
