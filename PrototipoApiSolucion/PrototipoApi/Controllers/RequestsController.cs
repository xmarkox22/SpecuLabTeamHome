using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PrototipoApi.Controllers
{
    [Route("api/requests")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        // Definición de endpoints para el controlador de Requests

        // GET: api/requests
        private readonly string _jsonPath = "Data/requests.json";

        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetAll()
        {
            if (!System.IO.File.Exists(_jsonPath))
                return NotFound("Archivo de datos no encontrado.");

            try
            {
                var json = System.IO.File.ReadAllText(_jsonPath);
                var requests = JsonSerializer.Deserialize<List<Request>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    });

                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al leer los datos: {ex.Message}");
            }
               
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

        [HttpPut("{estado}")]
        // Endpoint para mostrar todas las requests filtrando por estado
        public IActionResult GetByStatus(RequestStatus estado)
        {
            if (!System.IO.File.Exists(_jsonPath))
                return NotFound("Archivo de datos no encontrado.");

            try
            {
                var json = System.IO.File.ReadAllText(_jsonPath);
                var requests = JsonSerializer.Deserialize<List<Request>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    });

                var filtered = requests?.Where(r => r.Estado == estado).ToList() ?? new List<Request>();
                return Ok(filtered);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al leer los datos: {ex.Message}");
            }
        }

    }
}
