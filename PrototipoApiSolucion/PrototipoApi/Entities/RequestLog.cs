namespace PrototipoApi.Entities
{
    public class RequestLog
    {
        public int RequestLogId { get; set; }

        // Relaciones
        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;

        public DateTime LogDate { get; set; }
        public string Details { get; set; } = string.Empty;
    }

}
