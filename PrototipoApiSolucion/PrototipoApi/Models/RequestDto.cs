
using PrototipoApi.Entities;

namespace PrototipoApi.Models
{
    public class RequestDto
    {
        public int RequestDtoId { get; set; }
        public double BuilidingAmount { get; set; }
        public double MaintenanceAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = null!; // Relación con Status
        public Building Building { get; set; } = null!; // Relación con Building
    }
}
