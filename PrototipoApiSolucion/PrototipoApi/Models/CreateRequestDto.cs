using PrototipoApi.Entities;

namespace PrototipoApi.Models
{
    public class CreateRequestDto
    {
        public int RequestId { get; set; }

        /// <summary>
        /// Tipo de petición.
        /// Valores posibles: "COMPRA", "MANTENIMIENTO", "ALQUILER".
        /// </summary>
        public string RequestType { get; set; } = string.Empty;

        public double RequestAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }

    }
}
