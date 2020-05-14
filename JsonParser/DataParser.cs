using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JsonParser
{
    public class DataParser
    {
        public Dictionary<string, int> Parse(string jsonString)
        {
            JObject o = JObject.Parse(jsonString);
            var data = o["data"].ToString();
            var pattern = @"key = (\w+), age = (\w+)";
            var matches = Regex.Matches(data, pattern);
            var d = new Dictionary<string, int>();
            foreach(Match m in matches) 
            {
                var key = m.Groups[1].Value;
                var value = int.Parse(m.Groups[2].Value);

                d.Add(key, value);
            };

            return d;
        }
    }
}
