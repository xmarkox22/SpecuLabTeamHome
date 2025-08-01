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

        /// <summary>
        /// Tipo de petición.
        /// Valores posibles: "COMPRA", "MANTENIMIENTO", "ALQUILER".
        /// </summary>
        public string RequestType { get; set; } = string.Empty;

        public double RequestAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }

        // Relaciones
        public Status Status { get; set; } = null!;
        public int StatusId { get; set; } 
    }


}
