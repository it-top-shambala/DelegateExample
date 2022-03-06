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
    }
}