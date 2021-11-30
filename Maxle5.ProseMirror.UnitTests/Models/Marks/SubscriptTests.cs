using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
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
