using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
{
    public class BulleListTests
    {
        [Fact]
        public void Type_ShouldReturnBulleList()
        {
            // act
            var bulleList = new BulletList();

            // assert
            bulleList.Type.Should().Be("bulletList");
        }
    }
}
