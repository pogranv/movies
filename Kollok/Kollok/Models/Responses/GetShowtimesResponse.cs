namespace Kollok.Models.Responses;

public class GetShowtimesResponse
{
    /// <summary>
    /// Информаиця и сеансах
    /// </summary>
    public IEnumerable<Showtime> Showtimes { get; set; }
}