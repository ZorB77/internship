namespace Movie_WebAPI.Services
{
    public class LogService
    {
        private readonly string filePath = "C:\\Users\\user\\Documents\\git basics\\MovieApp\\WebAPI\\Movie_WebAPI\\Movie_WebAPI\\CallsLogs.txt";

        public void LogRequest(string message)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(message);
                writer.WriteLine("\n------\n");
            }
        }
    }
}
