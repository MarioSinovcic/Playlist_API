using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Playlist_Service;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        [HttpGet]
        [Route("songs")]
        public IActionResult GetPlaylists()
        {
            try
            {
                var songs = new List<Song>();
                var playlist = new Playlist(001, "Example", DateTime.Now, songs);
                return Ok(JsonSerializer.Serialize(playlist));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("songs/{id}")]
        public IActionResult GetSongs(int id)
        {
            try
            {
                var songs = new List<Song>();
                var playlist = new Playlist(id, "Example", DateTime.Now, songs);
                return Ok(JsonSerializer.Serialize(playlist));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
