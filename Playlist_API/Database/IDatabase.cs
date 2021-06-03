using System.Collections.Generic;
using Playlist_Service;

namespace Playlist_API.Database
{
    public interface IDatabase
    {
        public void CreatePlaylist(Playlist playlist);
        
        public List<Playlist> GetPlaylists();
        
        public Playlist GetPlaylist(int id);
        
        public void UpdatePlaylist(int id, Playlist playlist);
        
        public void DeletePlaylist(int id);

    }
}