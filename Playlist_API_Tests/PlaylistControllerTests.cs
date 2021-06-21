using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playlist_API_Tests.Mocks;
using Playlist_API.Controllers;
using Playlist_Service;
using Xunit;

namespace Playlist_API_Tests
{
    public class PlaylistControllerTests
    {
        private readonly PlaylistController _controller;

        public PlaylistControllerTests()
        {
            var database = new LocalDB();
            _controller = new PlaylistController(database);
        }
        

        [Fact]
        public async Task PlaylistGet_WithOutParameters_ShouldGetAllSongsFromThePlaylist()
        { 
            //Arrange //Act
            var result = await _controller.GetPlaylists();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            
            //Assert
            var model = Assert.IsAssignableFrom<string>(viewResult.Value);
            var playlists = JsonSerializer.Deserialize<List<Playlist>>(model);

            Assert.Equal(2, playlists.Count);
        }
    }
}