using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace _01.JSON_Serializer
{
    class JsonSerializer
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

            var serializer = new JavaScriptSerializer();
            string digitsJson = serializer.Serialize(digits);
            Console.WriteLine(digitsJson);

            var digitsDict = serializer.Deserialize<Dictionary<string, int>>(digitsJson);

            foreach (var d in digitsDict)
            {
                Console.WriteLine(d.Key + " --> " + d.Value);
            }
        }
    }
}