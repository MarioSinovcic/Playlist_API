namespace Playlist_API.Behaviours
{
    public static class NormalisationHelper
    {
        public static string Genre(string genre)
        {
            return genre.Replace(" ", "-").ToLower();
        }
    }
}