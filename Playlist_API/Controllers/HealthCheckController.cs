using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

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
                return StatusCode(500, "System down.");
            }
        }
    }
}
