using System;
using System.Collections.Generic;

namespace Playlist_Service
{
    public sealed record Playlist (int Id, string Name, DateTime CreationDate, List<Song> Songs);
}