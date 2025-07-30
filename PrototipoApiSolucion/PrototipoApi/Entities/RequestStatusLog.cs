namespace PrototipoApi.Entities
{
    public class RequestStatusLog
    {
        public int RequestStatusLogId { get; set; }

        // Relaciones
        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;

        public int OldStatusId { get; set; }
        public Status OldStatus { get; set; } = null!;

        public int NewStatusId { get; set; }
        public Status NewStatus { get; set; } = null!;

        public string Reason { get; set; } = string.Empty;
    }

}
