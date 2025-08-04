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
        public double BuilidingAmount { get; set; }
        public double MaintenanceAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }

        // Relaciones
        public Status Status { get; set; } = null!;
        public Building Building { get; set; } = null!;

    }


}
