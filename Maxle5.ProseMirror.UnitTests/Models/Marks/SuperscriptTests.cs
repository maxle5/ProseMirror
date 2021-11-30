using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class SuperscriptTests
    {
        [Fact]
        public void Type_ShouldReturnSubscript()
        {
            // act
            var subscript = new Superscript();

            // assert
            subscript.Type.Should().Be("superscript");
        }
    }
}
