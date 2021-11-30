using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class UnderlineTests
    {
        [Fact]
        public void Type_ShouldReturnUnderline()
        {
            // act
            var subscript = new Underline();

            // assert
            subscript.Type.Should().Be("underline");
        }
    }
}
