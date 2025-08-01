using PrototipoApi.Entities;

namespace PrototipoApi.Models
{
    public class CreateRequestDto
    {
        public int RequestId { get; set; }
        public required string RequestType { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required double RequestAmount { get; set; }
        public Status Status { get; set; } = new Status();
    }
}
