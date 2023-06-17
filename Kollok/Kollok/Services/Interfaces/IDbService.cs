using Kollok.Models;

namespace Kollok.Services.Interfaces;

public interface IDbService
{
    public IEnumerable<Movie> GetMovies();

    public IEnumerable<Showtime> GetShowtimes();
    public int BuyTickets(long sessionId, int countTickets);
}