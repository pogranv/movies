using System;
using System.Collections.Generic;
using Kollok.Models;

namespace Kollok
{
    public partial class Film
    {
        public Film()
        {
            Sessions = new HashSet<Session>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Genre { get; set; }
        public int Duration { get; set; }
        public int Rate { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public static Movie BuildMovie(Film film)
        {
            return new Movie
            {
                Name = film.Name,
                Genre = film.Genre,
                Duration = film.Duration,
                Rate = film.Rate
            };
        }
    }
}
