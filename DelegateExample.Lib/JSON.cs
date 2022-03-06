using System;
using System.IO;
using System.Text.Json;
using DelegateExample.Lib.Model;

namespace DelegateExample.Lib
{
    public class JSON
    {
        public string Path { get; set; }
        public Action<string> Info;
        public Action<string> Error;

        public void Export(Person person)
        {
            Info?.Invoke($"{DateTime.Now:g} : INFO : экспорт данных персоны в {Path}");
            try
            {
                using var file = new FileStream(Path, FileMode.Create);
                JsonSerializer.SerializeAsync(file, person);
                Info?.Invoke($"{DateTime.Now:g} : INFO : экспорт данных персоны в {Path} закончился");
            }
            catch (ArgumentException e)
            {
                Error?.Invoke($"{DateTime.Now:g} : ERROR : {e.Message}");
            }
            catch (NotSupportedException e)
            {
                Error?.Invoke($"{DateTime.Now:g} : ERROR : {e.Message}");
            }
        }

        public Person Import()
        {
            Info?.Invoke($"{DateTime.Now:g} : INFO : импорт данных персоны из {Path}");
            Person person = null;
            try
            {
                using var file = new FileStream(Path, FileMode.Open);
                person = JsonSerializer.DeserializeAsync<Person>(file).Result;
            }
            catch (ArgumentException e)
            {
                Error?.Invoke($"{DateTime.Now:g} : ERROR : {e.Message}");
            }
            catch (NotSupportedException e)
            {
                Error?.Invoke($"{DateTime.Now:g} : ERROR : {e.Message}");
            }

            return person;
        }
    }
}