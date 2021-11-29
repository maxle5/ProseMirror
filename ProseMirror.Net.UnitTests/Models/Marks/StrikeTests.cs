using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
{
    public class StrikeTests
    {
        [Fact]
        public void Type_ShouldReturnStrike()
        {
            // act
            var strike = new Strike();

            // assert
            strike.Type.Should().Be("strike");
        }
    }
}
