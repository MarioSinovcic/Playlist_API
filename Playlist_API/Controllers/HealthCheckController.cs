using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("healthcheck")]
        public async Task<IActionResult> GetHealthCheck() 
        {
            try
            {
                return Ok("Ok"); //TODO: look into what to return
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
