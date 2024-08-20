namespace MovieApplicationWebAPI.Utilities
{
    public class LogWriter
    {
        private readonly string filePath;

        public LogWriter(string filePath = "C:\\Users\\admin\\Documents\\GitHub\\internship\\MovieApplicationWebApi\\MovieApplicationWebAPI\\Utilities\\app.log")
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
