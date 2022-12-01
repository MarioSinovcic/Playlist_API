using System;

namespace Playlist_Service
{
    public sealed record Song (int Id, string Artist, string Name, DateTime ReleaseDate, string Link);
}