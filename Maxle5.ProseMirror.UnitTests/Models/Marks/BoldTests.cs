using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
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
