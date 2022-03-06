using System.IO;
using System.Text.Json;
using DelegateExample.Lib.Model;

namespace DelegateExample.Lib
{
    public class JSON
    {
        public string Path { get; set; }
        
        public void Export(Person person)
        {
            using var file = new FileStream(Path, FileMode.Create);
            JsonSerializer.SerializeAsync(file, person);
        }

        public Person Import()
        {
            using var file = new FileStream(Path, FileMode.Open);

            return JsonSerializer.DeserializeAsync<Person>(file).Result;
        }
    }
}