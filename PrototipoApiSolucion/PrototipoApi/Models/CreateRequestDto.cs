using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace PrototipoApi.Models
{
    public class CreateRequestDto : IValidatableObject
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto de construcción debe ser positivo.")]
        public double BuildingAmount { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El monto de mantenimiento debe ser positivo.")]
        public double MaintenanceAmount { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "El ID de estado debe ser válido.")]
        public int StatusId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El ID de edificio debe ser válido.")]
        public int BuildingId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Vacío (por ahora), pero conserva la herencia de IValidatableObject por si necesitas añadir reglas después.  
            yield break;
        }
    }

}
