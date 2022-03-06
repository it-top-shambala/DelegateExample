using System.Text.Json.Serialization;

namespace DelegateExample.Lib.Model
{
    public class Address
    {
        [JsonPropertyName("streetAddress")]
        public string StreetAddress { get; set; }
        
        [JsonPropertyName("city")]
        public string City { get; set; }
        
        [JsonPropertyName("postalCode")]
        public int PostalCode { get; set; }

        public Address()
        {
            StreetAddress = string.Empty;
            City = string.Empty;
            PostalCode = 0;
        }
        public Address(string streetAddress, string city, int postalCode)
        {
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
        }
    }
}