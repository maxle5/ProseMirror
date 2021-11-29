using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
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
