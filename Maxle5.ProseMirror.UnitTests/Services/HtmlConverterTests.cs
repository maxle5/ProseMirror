using FluentAssertions;
using Xunit;

namespace Maxle5.ProseMirror.UnitTests.Services
{
    public class HtmlConverterTests
    {
        private const string _expectedHtml = "<html><body><h1>A heading</h1><p> <strong>This is </strong>some text. <u>with underline text.</u> -<span style='color:#0d5bd9'> </span><em><span style='color:#0d5bd9'>w</span></em><strong><em><span style='color:#0d5bd9'>ith color</span></em></strong></p><p></p><p></p><p style='text-align: center'> <span style='color:#000000'>center alignment </span></p><p style='text-align: center'></p><ol> <li><p>an ordered list</p></li><li><p>item2</p></li><li><p>item3</p></li></ol><hr><ul> <li><p>item 1</p></li><li><p>item 2</p></li><li><p>item 3</p></li></ul><p></p><blockquote><p>some quoted text</p></blockquote><p></p><p> <a href='https://google.ca' target='_blank'>a hyperlink to google</a></p><p></p><img src='https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=1.00xw:0.669xh;0,0.190xh&amp;resize=1200:*' width='256'><p></p> <table><tbody> <tr> <th colspan='1' rowspan='1' colwidth='100'><p>First Name</p></th> <th colspan='1' rowspan='1' colwidth='100'><p>Last Name</p></th> </tr><tr> <td colspan='1' rowspan='1' colwidth='100'><p>Max</p></td><td colspan='1' rowspan='1' colwidth='100'><p>Lefebvre</p></td></tr><tr> <td colspan='1' rowspan='1' colwidth='100'><p>Luc</p></td><td colspan='1' rowspan='1' colwidth='100'><p>Lefebvre</p></td></tr><tr> <td colspan='1' rowspan='1' colwidth='100'><p>Liam</p></td><td colspan='1' rowspan='1' colwidth='100'><p>Lefebvre</p></td></tr></tbody></table></body></html>";
        private const string _expectedJson = "{\"type\":\"doc\",\"content\":[{\"attrs\":{\"level\":1,\"textAlign\":\"left\"},\"type\":\"heading\",\"content\":[{\"text\":\"A heading\",\"type\":\"text\"}]},{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"text\":\"This is \",\"type\":\"text\",\"marks\":[{\"type\":\"bold\"}]},{\"text\":\"some text. \",\"type\":\"text\"},{\"text\":\"with underline text.\",\"type\":\"text\",\"marks\":[{\"type\":\"underline\"}]},{\"text\":\" -\",\"type\":\"text\"},{\"text\":\" \",\"type\":\"text\",\"marks\":[{\"attrs\":{\"color\":\"#0d5bd9\"},\"type\":\"textStyle\"}]},{\"text\":\"w\",\"type\":\"text\",\"marks\":[{\"type\":\"italic\"},{\"attrs\":{\"color\":\"#0d5bd9\"},\"type\":\"textStyle\"}]},{\"text\":\"ith color\",\"type\":\"text\",\"marks\":[{\"type\":\"bold\"},{\"type\":\"italic\"},{\"attrs\":{\"color\":\"#0d5bd9\"},\"type\":\"textStyle\"}]}]},{\"attrs\":{},\"type\":\"paragraph\"},{\"attrs\":{},\"type\":\"paragraph\"},{\"attrs\":{\"textAlign\":\"center\"},\"type\":\"paragraph\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"text\":\"center alignment \",\"type\":\"text\",\"marks\":[{\"attrs\":{\"color\":\"#000000\"},\"type\":\"textStyle\"}]}]},{\"attrs\":{\"textAlign\":\"center\"},\"type\":\"paragraph\"},{\"type\":\"orderedList\",\"attrs\":{\"start\":1},\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"an ordered list\",\"type\":\"text\"}]}]},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"item2\",\"type\":\"text\"}]}]},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"item3\",\"type\":\"text\"}]}]}]},{\"type\":\"horizontalRule\"},{\"type\":\"bulletList\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"item 1\",\"type\":\"text\"}]}]},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"item 2\",\"type\":\"text\"}]}]},{\"type\":\"listItem\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"item 3\",\"type\":\"text\"}]}]}]},{\"attrs\":{},\"type\":\"paragraph\"},{\"type\":\"blockquote\",\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"some quoted text\",\"type\":\"text\"}]}]},{\"attrs\":{},\"type\":\"paragraph\"},{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"text\":\"a hyperlink to google\",\"type\":\"text\",\"marks\":[{\"attrs\":{\"target\":\"_blank\",\"href\":\"https://google.ca\"},\"type\":\"link\"}]}]},{\"attrs\":{},\"type\":\"paragraph\"},{\"attrs\":{\"alt\":null,\"src\":\"https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=1.00xw:0.669xh;0,0.190xh&amp;resize=1200:*\",\"title\":null,\"width\":256},\"type\":\"image\"},{\"attrs\":{},\"type\":\"paragraph\"},{\"text\":\" \",\"type\":\"text\"},{\"type\":\"table\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableRow\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableHeader\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"First Name\",\"type\":\"text\"}]}]},{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableHeader\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Last Name\",\"type\":\"text\"}]}]},{\"text\":\" \",\"type\":\"text\"}]},{\"type\":\"tableRow\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Max\",\"type\":\"text\"}]}]},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Lefebvre\",\"type\":\"text\"}]}]}]},{\"type\":\"tableRow\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Luc\",\"type\":\"text\"}]}]},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Lefebvre\",\"type\":\"text\"}]}]}]},{\"type\":\"tableRow\",\"content\":[{\"text\":\" \",\"type\":\"text\"},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Liam\",\"type\":\"text\"}]}]},{\"type\":\"tableCell\",\"attrs\":{\"colspan\":1,\"colwidth\":[100],\"rowspan\":1},\"content\":[{\"attrs\":{},\"type\":\"paragraph\",\"content\":[{\"text\":\"Lefebvre\",\"type\":\"text\"}]}]}]}]}]}";

        [Fact]
        public void Convert_ShouldReturnProseMirror_WhenValidArguments()
        {
            // arrange
            var converter = new HtmlConverter();

            // act
            var obj = converter.Convert(_expectedHtml);
            var json = ProseMirrorConvert.SerializeToJson(obj);

            // assert
            obj.Should().NotBeNull();
            json.Should().Be(_expectedJson);
        }

        [Fact]
        public void Convert_ShouldReturnHtml_WhenValidArguments()
        {
            // arrange
            var converter = new HtmlConverter();

            // act
            var obj = converter.Convert(_expectedHtml);
            var html = converter.Convert(obj);

            // assert
            html.Should().NotBeNull();
            html.Should().Be(_expectedHtml);
        }

        /// <summary>
        /// <example>
        /// <span>&gt;</span> -> ">"
        /// </example>
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnProseMirrorWithUnescapedText_WhenHtmlContainsEscapedContent()
        {
            // arrange
            var converter = new HtmlConverter();

            // act
            var obj = converter.Convert("<span>&gt;</span>");
            var json = ProseMirrorConvert.SerializeToJson(obj);

            // assert
            obj.Should().NotBeNull();
            json.Should().Be("{\"type\":\"doc\",\"content\":[{\"text\":\">\",\"type\":\"text\"}]}");
        }

        /// <summary>
        /// <example>
        /// ">" -> <span>&gt;</span> 
        /// </example>
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnEscapedHtml_WhenProseMirrorContainsUnescapedContent()
        {
            // arrange
            var converter = new HtmlConverter();
            const string expectedHtml = "<html><body>&gt;</body></html>";

            // act
            var obj = converter.Convert(expectedHtml);
            var html = converter.Convert(obj);

            // assert
            obj.Should().NotBeNull();
            html.Should().Be(expectedHtml);
        }
    }
}