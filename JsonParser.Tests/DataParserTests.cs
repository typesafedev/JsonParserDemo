using Shouldly;
using System.Linq;
using Xunit;

namespace JsonParser.Tests
{
    public class DataParserTests
    {
        [Fact]
        public void ShouldParseExample()
        {
            var json = "{\"data\":\"key = IAfpK, age = 58, key = WNVdi, age = 64, key = jp9zt, age = 47\"}";
            var sut = new DataParser();

            var dict = sut.Parse(json);

            dict["IAfpK"].ShouldBe(58);
            dict["WNVdi"].ShouldBe(64);
            dict["jp9zt"].ShouldBe(47);
        }

        [Fact]
        public void ShouldParseExampleAndFilter()
        {
            var json = "{\"data\":\"key = IAfpK, age = 58, key = WNVdi, age = 64, key = jp9zt, age = 47\"}";
            var sut = new DataParser();

            var dict = sut.Parse(json);

            dict.Where(kvp => kvp.Value > 50).Count().ShouldBe(2);
        }
    }
}
