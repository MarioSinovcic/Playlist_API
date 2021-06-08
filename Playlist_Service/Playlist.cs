using System;
using System.Collections.Generic;

namespace Playlist_Service
{
    public class Playlist
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public DateTime CreationDate { get; init; }
        public List<Song> Songs { get; }

        public Playlist(int id, string name, DateTime creationDate, List<Song> songs)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
            Songs = songs;
        }

        public void AddSong(Song song)
        {
            if (!Songs.Contains(song))
            {
                Songs.Add(song);
            }
        }
    }
}