using System;
using System.Collections.Generic;
using System.IO;
using DelegateExample.Lib;
using DelegateExample.Lib.Model;

namespace DelegateExample.App
{
    internal static class Program
    {
        private static void Main()
        {
            var json = new JSON
            {
                Path = "",
                Person = new Person
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
                },
                Info = msg => Print(msg, ConsoleColor.Blue),
                Error = msg => Print(msg, ConsoleColor.Red)
            };
            json.Info += Log;
            json.Error += Log;
            
            json.Export();

            json.Import();
            var person = json.Person;
            Console.WriteLine($"{person.LastName} {person.FirstName}");
        }

        static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Log(string message)
        {
            using var file = new StreamWriter("example.log", append:true);
            file.WriteLine(message);
        }
    }
}