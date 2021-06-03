using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Playlist_API.Database;
using Playlist_Service;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IDatabase _database = new LocalDatabase();

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
        public IActionResult GetPlaylists()
        {
            try
            {
                var playlists = _database.GetPlaylists();
                if (playlists.Count == 0)
                {
                    return NotFound();
                }
                return Ok(JsonConvert.SerializeObject(playlists));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("playlists/{id}")]
        public IActionResult GetPlaylist([FromRoute]int id) //change this later
        {
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
