using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
{
    public class BoldTests
    {
        [Fact]
        public void Type_ShouldReturnBold()
        {
            // act
            var bold = new Bold();

            // assert
            bold.Type.Should().Be("bold");
        }
    }
}
