using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Playlist_API_Tests.Mocks;
using Playlist_API.Controllers;
using Playlist_Service;
using Assert = Xunit.Assert;

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
        

        [Test]
        public void PlaylistGet_WithOutParameters_ShouldGetAllSongsFromThePlaylist()
        { 
            //Arrange //Act
            var result = _controller.GetPlaylists();
            var viewResult = Assert.IsType<ObjectResult>(result);
            
            //Assert
            var model = Assert.IsAssignableFrom<string>(viewResult.Value);
            var playlists = JsonSerializer.Deserialize<List<Playlist>>(model);

            Assert.NotNull(playlists);
            Assert.Equal(2, playlists.Count);
        }
    }
}