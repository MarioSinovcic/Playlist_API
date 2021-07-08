using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        [Route("healthcheck")]
        public ObjectResult GetHealthCheck() 
        {
            try
            {
                var message = new HealthCheckMessage("mario-playlist-api", "UP", "1.0.2");
                var json = JsonConvert.SerializeObject(message);
                return StatusCode(200, json); 
            }
            catch (Exception)
            {
                var message = new HealthCheckMessage("mario-playlist-api", "DOWN", null);
                var json = JsonConvert.SerializeObject(message);
                return StatusCode(500, json);
            }
        }
    }
}
