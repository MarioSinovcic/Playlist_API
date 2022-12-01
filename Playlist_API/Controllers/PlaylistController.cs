using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Playlist_API.Database;
using Playlist_Service;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly IDatabase _database;
        public PlaylistController(IDatabase database)
        {
            _database = database;
        }

        [HttpPut]
        [Route("playlists")]
        public IActionResult CreatePlaylist(Playlist playlist)
        {
            try
            {
                _database.CreatePlaylist(playlist);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpPost]
        [Route("playlists/{id}")]
        public IActionResult UpdatePlaylist([FromRoute]int id, Playlist playlist)
        {
            var rgx = new Regex("^[0-9A-Za-z]+$");
            if (!rgx.IsMatch(id.ToString())) return StatusCode(400, "ID specified is invalid.");
            
            

            try
            {
                _database.UpdatePlaylist(id, playlist);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("playlists")]
        public ObjectResult GetPlaylists()
        {
            try
            {
                var playlists = _database.GetPlaylists();
                if (playlists.Count == 0) return NotFound("No playlists have been made yet.");
                
                return StatusCode(200, JsonConvert.SerializeObject(playlists));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving playlists.");
            }
        }
        
        [HttpGet]
        [Route("playlists/{id}")]
        public IActionResult GetPlaylist([FromRoute]int id) 
        {
            var rgx = new Regex("^[0-9A-Za-z]+$");
            if (!rgx.IsMatch(id.ToString())) return StatusCode(400, "ID specified is invalid.");

            try
            {
                var playlist = _database.GetPlaylist(id);
                return Ok(JsonConvert.SerializeObject(playlist));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("playlists/{id}")]
        public IActionResult DeletePlaylist([FromRoute]int id)
        {
            var rgx = new Regex("^[0-9A-Za-z]+$");
            if (!rgx.IsMatch(id.ToString())) return StatusCode(400, "ID specified is invalid.");

            try
            {
                _database.DeletePlaylist(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
