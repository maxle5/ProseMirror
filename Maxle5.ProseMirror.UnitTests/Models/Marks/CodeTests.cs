using FluentAssertions;
using Maxle5.ProseMirror.Models.Marks;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Models.Marks
{
    public class CodeTests
    {
        [Fact]
        public void Type_ShouldReturnCode()
        {
            // act
            var code = new Code();

            // assert
            code.Type.Should().Be("code");
        }
    }
}
