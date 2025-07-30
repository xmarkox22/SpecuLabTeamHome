namespace PrototipoApi.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public DateTime StatusDate { get; set; }
        public string Description { get; set; } = string.Empty;

        // Relaciones
        public ICollection<Request> Requests { get; set; } = new List<Request>();
    }

}
