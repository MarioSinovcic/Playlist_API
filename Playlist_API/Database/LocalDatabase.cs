using System;
using System.Collections.Generic;
using System.Linq;
using Playlist_Service;
    
namespace Playlist_API.Database
{
    public class LocalDatabase : IDatabase
    {
        private readonly List<Playlist> _playlists;

        public LocalDatabase()
        {
            _playlists = new List<Playlist>();
            Populate();
        }

        public void CreatePlaylist(Playlist playlist)
        {
            _playlists.Add(playlist);
        }

        public List<Playlist> GetPlaylists()
        {
            return _playlists;
        }

        public Playlist GetPlaylist(int id)
        {
            return _playlists.FirstOrDefault(x => x.Id == id);
        }

        public void UpdatePlaylist(int id, Playlist playlist)
        {
            foreach (var p in _playlists)
            {
                if (p.Id == id)
                {
                    var i = _playlists.IndexOf(p);
                    _playlists[i] = playlist;
                }
            }
        }

        public void DeletePlaylist(int id)
        {
            _playlists.RemoveAll(x => x.Id == id);
        }
        
        private void Populate()
        {
            var song1 = new Song(3423214, "George Micheal", "Careless Whisper", DateTime.Now,
                "https://www.youtube.com/watch?v=izGwDsrQ1eQ");
            var song2 = new Song(6113214, "Gerry Rafferty", "Baker Street", DateTime.Now,
                "https://www.youtube.com/watch?v=6tynWSAesAo");
            var song3 = new Song(8912144, "TOTO", "Africa", DateTime.Now,
                "https://www.youtube.com/watch?v=QAo_Ycocl1E&ab_channel=TOTOTOTOOfficialArtistChannel");
            
            var p1songs = new List<Song>() {song1, song2, song3};
            
            _playlists.Add(new Playlist(0001, "Classics", DateTime.Now,p1songs));
            
            var song4 = new Song(9123214, "Armand Van Helden", "You Don't Know Me", DateTime.Now,
                "https://www.youtube.com/watch?v=a8u5-CnmJk8&ab_channel=DJEPhunk");
            var song5 = new Song(5557979, "Crystal Waters", "Gypsy Woman", DateTime.Now,
                "https://www.youtube.com/watch?v=_KztNIg4cvE&ab_channel=CrystalWatersVEVOCrystalWatersVEVOVerified");
            
            var p2songs = new List<Song>() {song4, song5};
            
            _playlists.Add(new Playlist(0002, "House", DateTime.Now,p2songs));

        }
    }
}