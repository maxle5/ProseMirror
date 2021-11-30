using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
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
