namespace PrototipoApi.Logging
{
    public interface ILoguer
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception? ex = null);
    }
}
