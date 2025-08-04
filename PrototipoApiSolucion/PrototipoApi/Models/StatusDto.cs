using PrototipoApi.Entities;

namespace PrototipoApi.Models
{
    public class StatusDto
    {
        public int StatusId { get; set; }
        public string StatusType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
