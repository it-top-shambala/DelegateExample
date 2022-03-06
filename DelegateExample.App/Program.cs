using System;
using DelegateExample.Lib;
using DelegateExample.Lib.Model;

namespace DelegateExample.App
{
    internal static class Program
    {
        private static void Main()
        {
            var exit = false;
            
            var person = new Person();
            
            var log = new LogToFile { Path = "demo.log" };
            
            var json = new JSON
            {
                Person = person,
                Path = "person.json"
            };
            json.InfoRegister(log.Log, CLI.PrintInfo);
            json.ErrorRegister(log.Log, CLI.PrintError);

            var menu = new Menu(
                json.Export, 
                json.Import, 
                () => EditPerson(json.Person), 
                () => ShowPerson(json.Person), 
                () => exit = true
                );

            do
            {
                Console.WriteLine("Выберите пункт меню:");
                foreach (var (item, name) in menu.menuS)
                {
                    Console.WriteLine($"{item}: {name}");
                }

                var select = Convert.ToInt32(Console.ReadLine());
                menu.menu[select]?.Invoke();
            } while (!exit);
        }

        private static void EditPerson(Person person)
        {
            
        }

        private static void ShowPerson(Person person)
        {
            CLI.Show("=== PERSON ===");
            CLI.Show($"Last name: {person.LastName}");
            CLI.Show($"First name: {person.FirstName}");
            CLI.Show($"Postal code: {person.Address.PostalCode}");
            CLI.Show($"City: {person.Address.City}");
            CLI.Show($"Street: {person.Address.StreetAddress}");
            CLI.Show("Phone numbers:");
            foreach (var phoneNumber in person.PhoneNumbers)
            {
                CLI.Show(phoneNumber);
            }
            CLI.Show("=== === ===");
        }
    }
}