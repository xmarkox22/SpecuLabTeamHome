using System.ComponentModel.DataAnnotations;

namespace PrototipoApi.Models
{
    public class UpdateRequestDto
    {
        // Campo requerido
        // La cantidad debe ser un número positivo
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public double MaintenanceAmount { get; set; }
    }
}
