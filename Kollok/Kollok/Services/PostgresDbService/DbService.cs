using Kollok.Models;
using Kollok.Services.Exceptions;
using Kollok.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kollok;

public class DbService : IDbService
{
    public IEnumerable<Movie> GetMovies()
    {
        using (CinemaContext db = new CinemaContext())
        {
            var pgMovies = db.Films.ToList();
            var movies = new List<Movie>();
            foreach (var pgMovie in pgMovies)
            {
                movies.Add(Film.BuildMovie(pgMovie));
            }

            return movies;
        }
    }

    public IEnumerable<Showtime> GetShowtimes()
    {
        using (CinemaContext db = new CinemaContext())
        {
            var pgSessions = db.Sessions.Include(session => session.Movie).ToList();
            var showtimes = new List<Showtime>();
            foreach (var pgSession in pgSessions)
            {
                showtimes.Add(Session.BuildShowtime(pgSession));
            }

            return showtimes;
        }
    }

    public int BuyTickets(long sessionId, int countTickets)
    {
        using (CinemaContext db = new CinemaContext())
        {
            var session = db.Sessions.FirstOrDefault(session => session.Id == sessionId);
            if (session == null || session.Available < countTickets)
            {
                throw new NotEnoughTicketsException("Недостаточно доступных билетов!");
            }

            session.Available -= countTickets;
            var remainsTickets = session.Available;
            db.SaveChanges();
            return remainsTickets;
        }
    }
}