using System;
using System.IO;
using System.Text.Json;
using DelegateExample.Lib.Model;

namespace DelegateExample.Lib
{
    public class JSON
    {
        public string Path { get; set; }
        public Person Person { get; set; }
        
        public Action<string> Info;
        public Action<string> Error;

        private void Exec(string message, Action action)
        {
            Info?.Invoke($"{DateTime.Now:g} : START : {message}");
            try
            {
                action?.Invoke();
                Info?.Invoke($"{DateTime.Now:g} : STOP : {message}");
            }
            catch (Exception e)
            {
                Error?.Invoke($"{DateTime.Now:g} : ERROR : {e.Message}");
            }
        }
        
        public void Export()
        {
            Exec($"экспорт данных персоны в {Path}", () =>
            {
                using var file = new FileStream(Path, FileMode.Create);
                JsonSerializer.SerializeAsync(file, Person);
            });
        }

        public void Import()
        {
            Exec($"импорт данных персоны из {Path}", () =>
            {
                using var file = new FileStream(Path, FileMode.Open);
                Person = JsonSerializer.DeserializeAsync<Person>(file).Result;
            });
        }
    }
}