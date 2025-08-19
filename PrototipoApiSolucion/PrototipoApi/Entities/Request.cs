using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoApi.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public double BuildingAmount { get; set; }
        public double MaintenanceAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }

        // Claves foráneas (necesarias para asignar desde el DTO)
        public int StatusId { get; set; }
        public int BuildingId { get; set; }
        public string BuildingCode { get; set; }

        // Navegación
        public Status Status { get; set; } = null!;
        public Building Building { get; set; } = null!;
    }


}
