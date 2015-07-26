using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _02.JSON.NET
{
    class JsonDotNetExample
    {
        static void Main()
        {
            var digits = new Dictionary<string, int>()
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5}
            };

            var digitsJson = JsonConvert.SerializeObject(digits);
            Console.WriteLine(digitsJson);

            var deserializedDigits = JsonConvert.DeserializeObject<Dictionary<string, int>>(digitsJson);

            foreach (var digit in deserializedDigits)
            {
                Console.WriteLine(digit.Key + " ---> " + digit.Value);
            }

        }
    }
}