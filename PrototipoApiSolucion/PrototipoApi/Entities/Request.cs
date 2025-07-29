using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoApi.Entities
{
    public class Request
    {
        public Guid Id { get; set; }
        public TipoSolicitud Tipo { get; set; }
        public double ImporteSolicitado { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
        public RequestStatus Estado { get; set; } = RequestStatus.Received;
    }

    public enum TipoSolicitud
    {
        Compra,
        Mantenimiento,
        Alquiler
    }


}
