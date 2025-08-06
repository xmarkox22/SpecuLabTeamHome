namespace PrototipoApi.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

}
