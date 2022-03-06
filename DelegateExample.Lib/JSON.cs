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
        
        private Action<string> Info;
        private Action<string> Error;

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

        private void RegisterActions(Action<string> action, params Action<string>[] actions)
        {
            action = actions[0];
            for (int i = 1; i < actions.Length; i++)
            {
                action += actions[i];
            }
        }
        public void InfoRegister(params Action<string>[] actions)
        {
            RegisterActions(Info, actions);
        }
        
        public void ErrorRegister(params Action<string>[] actions)
        {
            RegisterActions(Error, actions);
        }
    }
}