using FluentAssertions;
using Maxle5.ProseMirror.Models.Nodes;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Nodes
{
    public class DocumentTests
    {
        [Fact]
        public void Type_ShouldReturnDocument()
        {
            // act
            var document = new Document();

            // assert
            document.Type.Should().Be("doc");
        }
    }
}
