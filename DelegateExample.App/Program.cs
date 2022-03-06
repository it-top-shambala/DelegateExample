using System;
using System.Collections.Generic;
using DelegateExample.Lib;
using DelegateExample.Lib.Model;

namespace DelegateExample.App
{
    internal static class Program
    {
        private static void Main()
        {
            var person = new Person
            {
                FirstName = "Andrey",
                LastName = "Starinin",
                Address = new Address
                {
                    StreetAddress = "Street",
                    City = "Voronezh",
                    PostalCode = 390000
                },
                PhoneNumbers = new List<string>
                {
                    "+79042144491",
                    "2575755"
                }
            };

            var json = new JSON
            {
                Path = "person.json"
            };
            
            json.Export(person);

            var starinin = json.Import();
            Console.WriteLine($"{starinin.LastName} {starinin.FirstName}");
        }
    }
}