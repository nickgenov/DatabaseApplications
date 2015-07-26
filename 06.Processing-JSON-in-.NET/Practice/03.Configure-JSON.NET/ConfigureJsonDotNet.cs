using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _03.Configure_JSON.NET
{
    class ConfigureJsonDotNet
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

            //Formatting output:
            var digitsJson = JsonConvert.SerializeObject(digits, Formatting.Indented);
            Console.WriteLine(digitsJson);

            var trainers = @"{ 'firstName': 'Vladimir',
                            'lastName': 'Georgiev',               
                            'jobTitle': 'Technical Trainer' }";

            var template = new
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                JobTitle = string.Empty
            };

            var deserializedTrainers = JsonConvert.DeserializeAnonymousType(trainers, template);

            Console.WriteLine(deserializedTrainers);

        }
    }
}