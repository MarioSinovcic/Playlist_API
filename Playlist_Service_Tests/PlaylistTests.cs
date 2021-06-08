using System;
using System.Collections.Generic;
using NUnit.Framework;
using Playlist_Service;

namespace Playlist_Service_Tests
{
    public class PlaylistTests
    {

        [Test]
        public void PlaylistUpdate_WithNewValidSong_ShouldAddSongToPlaylist()
        {
            //Arrange
            var song1 = new Song(3423214, "George Micheal", "Careless Whisper", DateTime.Now,
                "https://www.youtube.com/watch?v=izGwDsrQ1eQ");
            var playlistSongs = new List<Song> {song1};
            var playlist = new Playlist(0001, "Classics", DateTime.Now, playlistSongs);
            
            //Act
            var song2 = new Song(6113214, "Gerry Rafferty", "Baker Street", DateTime.Now,
                "https://www.youtube.com/watch?v=6tynWSAesAo");
            playlist.AddSong(song2);
            
            //Assert
            Assert.AreEqual(2,playlist.Songs.Count);
        }
        
        [Test]
        public void PlaylistUpdate_WithExistingSong_ShouldNotAddSongToPlaylist()
        {
            //Arrange
            var song1 = new Song(3423214, "George Micheal", "Careless Whisper", DateTime.Now,
                "https://www.youtube.com/watch?v=izGwDsrQ1eQ");
            var playlistSongs = new List<Song> {song1};
            var playlist = new Playlist(0001, "Classics", DateTime.Now, playlistSongs);
            
            //Act
            playlist.AddSong(song1);
            
            //Assert
            Assert.AreEqual(1,playlist.Songs.Count);
        }
    }
}