using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWithForm.Utilities
{
    public class LogWriter
    {
        private readonly string filePath;

        public LogWriter(string filePath)
        {
            this.filePath = filePath;
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        public void Log(string message)
        {
            try
            {
                File.AppendAllText(filePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
