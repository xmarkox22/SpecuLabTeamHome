using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MensajeSolicitud
    {
        public Guid Id { get; set; }
        public TipoSolicitud Tipo { get; set; }
        public double ImporteSolicitado { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
        public RequestStatus Status { get; set; } 
    }

    public enum TipoSolicitud
    {
        Compra,
        Mantenimiento,
        Alquiler
    }

}
