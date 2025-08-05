namespace PrototipoApi.Models
{
    public class CreateRequestDto
    {
        public double BuildingAmount { get; set; }
        public double MaintenanceAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int BuildingId { get; set; }
    }

}
