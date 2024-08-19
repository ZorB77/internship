namespace Movie_WebAPI.Services
{
    public class LogService
    {
        private readonly string requestFilePath = "C:\\Users\\user\\Documents\\git basics\\MovieApp\\WebAPI\\Movie_WebAPI\\Movie_WebAPI\\CallsLogs.txt";
        private readonly string responseFilePath = "C:\\Users\\user\\Documents\\git basics\\MovieApp\\WebAPI\\Movie_WebAPI\\Movie_WebAPI\\ResponseLogs.txt";

        public void LogRequest(string message)
        {
            if (!File.Exists(requestFilePath))
            {
                File.Create(requestFilePath).Close();
            }

            using (var writer = new StreamWriter(requestFilePath, true))
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(message);
                writer.WriteLine("\n------\n");
            }
        }

        public void LogResponse(string message)
        {
            if (!File.Exists(responseFilePath))
            {
                File.Create(responseFilePath).Close();
            }

            using (var writer = new StreamWriter(responseFilePath, true))
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(message);
                writer.WriteLine("\n------\n");
            }
        }
    }
}
