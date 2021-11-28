using FluentAssertions;
using Xunit;

namespace ProseMirror.Net.UnitTests
{
    public class HtmlConverterTests
    {
        private const string _expectedJson = "";

        [Fact]
        public void Convert_ShouldReturnProseMirror_WhenValidArguments()
        {
            // arrange
            var converter = new HtmlConverter();
            const string html = "<html><head><meta charset='utf-8'><meta http-equiv='X-UA-Compatible' content='IE=edge'><title>Test Page</title></head><body><h1>Test Page</h1><p> This<em>is my test</em> page,<u>it even</u> has<strong>bold text!!!</strong></p><img src='https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png' alt='Google Logo'/><table><tr><th>Name</th><th>Age</th></tr><tr><td>John</td><td>25</td></tr><tr><td>Jane</td><td>32</td></tr></table><br/><ul><li>Item 1</li><li>Item 2</li><li>Item 3</li></ul></html>";

            // act
            var obj = converter.Convert(html);

            // assert
            obj.Should().NotBeNull();
        }
    }
}
