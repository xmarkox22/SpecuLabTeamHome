namespace PrototipoApi.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
