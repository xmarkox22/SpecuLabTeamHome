using System.ComponentModel.DataAnnotations.Schema;

namespace PrototipoApi.Entities
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentCode { get; set; } = string.Empty;
        public string ApartmentDoor { get; set; } = string.Empty;
        public string ApartmentFloor { get; set; } = string.Empty;
        public decimal ApartmentPrice { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int BuildingId { get; set; }
        public bool HasLift { get; set; }
        public bool HasGarage { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("BuildingId")]
        public Building Building { get; set; } = null!;
    }
}
