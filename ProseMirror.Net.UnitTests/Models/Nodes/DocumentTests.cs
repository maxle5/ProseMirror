using FluentAssertions;
using ProseMirror.Net.Models.Nodes;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Nodes
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
