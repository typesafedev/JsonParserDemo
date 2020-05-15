using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JsonParser
{
    public class DataParser
    {
        public IEnumerable<Data> Parse(string jsonString)
        {
            JObject o = JObject.Parse(jsonString);
            var data = o["data"].ToString();
            var pattern = @"key = (\w+), age = (\w+)";
            var matches = Regex.Matches(data, pattern);
            foreach(Match m in matches) 
            {
                var key = m.Groups[1].Value;
                var value = int.Parse(m.Groups[2].Value);
                yield return new Data { Id = key, Age = value };
            };
        }

        public IEnumerable<Data> ParseWithLinq(string jsonString)
        {
            static string stripKeyPrefix(string input) => input.Substring(6);
            static string stripAgePrefix(string input) => input.Substring(6);
            JObject o = JObject.Parse(jsonString);
            var data = o["data"].ToString();
            var csvStrings = data.Split(", ");
            var pairwise = csvStrings.Zip(csvStrings.Skip(1), (string key, string value) => (key, value));
            var results = pairwise
                .Where(p => p.key.StartsWith("key"))
                .Select(p => new Data
                {
                    Id = stripKeyPrefix(p.key),
                    Age = int.Parse(stripAgePrefix(p.value))
                });

            return results;
        }
    }
}
