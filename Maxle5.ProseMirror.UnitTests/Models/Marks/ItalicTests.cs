using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class ItalicTests
    {
        [Fact]
        public void Type_ShouldReturnItalic()
        {
            // act
            var italic = new Italic();

            // assert
            italic.Type.Should().Be("italic");
        }
    }
}
