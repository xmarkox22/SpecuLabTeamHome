using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrototipoApi.Controllers
{
    [Route("api/requests")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        // Definición de endpoints para el controlador de Requests

        // GET: api/requests

        [HttpGet]
        public IActionResult Get()
        {
            // Listar objetos request. Crear una lista de ejemplo para la demostración.
            var requests = new List<Entities.Request>
            {
                new Entities.Request
                {
                    Id = Guid.NewGuid(),
                    Tipo = Entities.TipoSolicitud.Compra,
                    ImporteSolicitado = 1000.00,
                    Descripcion = "Compra de material de oficina",
                    FechaSolicitud = DateTime.UtcNow,
                    Estado = Entities.RequestStatus.Received
                },
                new Entities.Request
                {
                    Id = Guid.NewGuid(),
                    Tipo = Entities.TipoSolicitud.Mantenimiento,
                    ImporteSolicitado = 500.00,
                    Descripcion = "Mantenimiento de equipos informáticos",
                    FechaSolicitud = DateTime.UtcNow,
                    Estado = Entities.RequestStatus.PendingReview
                }
            };
            return Ok(requests);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            // Obtener un objeto request por ID. Crear un objeto de ejemplo para la demostración.
            var request = new Entities.Request
            {
                Id = id,
                Tipo = Entities.TipoSolicitud.Alquiler,
                ImporteSolicitado = 2000.00,
                Descripcion = "Alquiler de maquinaria pesada",
                FechaSolicitud = DateTime.UtcNow,
                Estado = Entities.RequestStatus.Accepted
            };
            return Ok(request);
        }
    }
}
