namespace PrototipoApi.Entities
{
    public class Status
    {
        public Guid StatusId { get; set; }
        public string StatusType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
