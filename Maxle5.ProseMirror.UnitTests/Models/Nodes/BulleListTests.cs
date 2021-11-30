using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
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
