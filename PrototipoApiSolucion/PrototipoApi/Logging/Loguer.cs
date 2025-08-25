using System;

namespace PrototipoApi.Logging
{
    public class Loguer : ILoguer
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"[WARN] {DateTime.Now}: {message}");
        }

        public void LogError(string message, Exception? ex = null)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now}: {message}");
            if (ex != null)
                Console.WriteLine($"Exception: {ex}");
        }
    }
}
