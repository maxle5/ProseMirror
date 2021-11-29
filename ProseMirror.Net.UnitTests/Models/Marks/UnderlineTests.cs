using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
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
