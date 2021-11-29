using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
{
    public class SubscriptTests
    {
        [Fact]
        public void Type_ShouldReturnSubscript()
        {
            // act
            var subscript = new Subscript();

            // assert
            subscript.Type.Should().Be("subscript");
        }
    }
}
