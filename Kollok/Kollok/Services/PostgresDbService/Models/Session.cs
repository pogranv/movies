using System;
using System.Collections.Generic;
using Kollok.Models;

namespace Kollok
{
    public partial class Session
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public DateOnly SessionDate { get; set; }
        public TimeOnly SessionTime { get; set; }
        public int Available { get; set; }

        public virtual Film Movie { get; set; } = null!;

        public static Showtime BuildShowtime(Session session)
        {
            return new Showtime
            {
                MovieName = session.Movie.Name,
                Available = session.Available,
                SessionDate = session.SessionDate.ToString(),
                SessionTime = session.SessionTime.ToString(),
            };
        }
    }
}
