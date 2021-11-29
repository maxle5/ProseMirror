using FluentAssertions;
using ProseMirror.Net.Models.Marks;
using Xunit;

namespace ProseMirror.Net.UnitTests.Models.Marks
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
