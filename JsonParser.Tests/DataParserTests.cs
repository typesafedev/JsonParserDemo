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

            var seq = sut.Parse(json);

            seq.Single(s => s.Id == "IAfpK").Age.ShouldBe(58);
            seq.Single(s => s.Id == "WNVdi").Age.ShouldBe(64);
            seq.Single(s => s.Id == "jp9zt").Age.ShouldBe(47);
        }

        [Fact]
        public void ShouldParseExampleAndFilter()
        {
            var json = "{\"data\":\"key = IAfpK, age = 58, key = WNVdi, age = 64, key = jp9zt, age = 47\"}";
            var sut = new DataParser();

            var seq = sut.Parse(json);

            seq.Where(s => s.Age > 50).Count().ShouldBe(2);
        }

        [Fact]
        public void ShouldParseExampleWithLinq()
        {
            var json = "{\"data\":\"key = IAfpK, age = 58, key = WNVdi, age = 64, key = jp9zt, age = 47\"}";
            var sut = new DataParser();

            var seq = sut.ParseWithLinq(json);

            seq.Single(s => s.Id == "IAfpK").Age.ShouldBe(58);
            seq.Single(s => s.Id == "WNVdi").Age.ShouldBe(64);
            seq.Single(s => s.Id == "jp9zt").Age.ShouldBe(47);
        }

        [Fact]
        public void ShouldParseExampleWithLinqAndFilter()
        {
            var json = "{\"data\":\"key = IAfpK, age = 58, key = WNVdi, age = 64, key = jp9zt, age = 47\"}";
            var sut = new DataParser();

            var seq = sut.ParseWithLinq(json);

            seq.Where(s => s.Age > 50).Count().ShouldBe(2);
        }
    }
}
