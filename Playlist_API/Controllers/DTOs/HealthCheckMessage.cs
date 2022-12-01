namespace Playlist_API.Controllers
{
    internal sealed record HealthCheckMessage(string application, string status, string version);
}