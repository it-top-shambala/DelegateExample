using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DelegateExample.Lib.Model
{
    public class Person
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        
        [JsonPropertyName("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }

        public Person()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = new Address();
            PhoneNumbers = new List<string>();
        }

        public Person(string firstName, string lastName, Address address, List<string> phoneNumbers)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumbers = phoneNumbers;
        }
    }
}