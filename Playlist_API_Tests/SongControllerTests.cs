using Microsoft.AspNetCore.Mvc;
using Playlist_API_Tests.Mocks;
using Playlist_API.Behaviours.Spotify;
using Playlist_API.Controllers;
using Xunit;

namespace Playlist_API_Tests
{
    public class SongControllerTests
    {
        private SongController _controller;
        
        private void SetupController(ISpotifyService service)
        {
            _controller = new SongController(service);
        }
        
        [Fact]
        public async void GetSong_WithInvalidToken_ShouldReturn503()
        { 
            //Arrange
            var spotifyClient = new NullSpotifyClient(true);
            SetupController(spotifyClient);

            //Act
            var result = await _controller.GetRandomSong("") as ObjectResult;
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(503,result.StatusCode);
        }      
        

        [Fact]
        public async void GetSong_WithInvalidGenre_ShouldReturn404()
        { 
            //Arrange
            var spotifyClient = new LocalSpotifyClient(false);
            SetupController(spotifyClient);

            //Act
            var result = await _controller.GetRandomSong("Techno") as ObjectResult;
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(404,result.StatusCode);
        }      
        
        [Fact]
        public async void GetSong_WithValidGenre_ShouldReturn200()
        { 
            //Arrange
            var spotifyClient = new LocalSpotifyClient(false);
            SetupController(spotifyClient);
            
            //Act
            var result = await _controller.GetRandomSong("Hip Hop") as ObjectResult;
            
            //Assert
            Assert.Equal(200,result.StatusCode);
        }
        
        [Fact]
        public async void GetSong_WithValidGenre_ShouldReturnCorrectBody()
        { 
            //Arrange
            var spotifyClient = new LocalSpotifyClient(false);
            SetupController(spotifyClient);
            
            //Act
            var result = await _controller.GetRandomSong("Hip Hop") as ObjectResult;
            
            //Assert
            Assert.Equal("Example Song",result.Value);
        }
    }
}