using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrototipoApi.Controllers
{
    [Route("api/solicitud")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        // Definición de endpoints para el controlador Solicitud

        // GET: api/solicitud

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Solicitud GET endpoint reached");
        }
    }
}
