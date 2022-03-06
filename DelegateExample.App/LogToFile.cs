using System.IO;

namespace DelegateExample.App
{
    public class LogToFile
    {
        public string Path { get; set; }
        
        public void Log(string message)
        {
            using var file = new StreamWriter(Path, append:true);
            file.WriteLine(message);
        }
    }
}