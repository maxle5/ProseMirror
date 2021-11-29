using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
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
