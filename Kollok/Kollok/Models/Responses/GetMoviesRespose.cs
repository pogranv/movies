namespace Kollok.Models.Responses;

public class GetMoviesRespose
{
    /// <summary>
    /// Информация о фильмах.
    /// </summary>
    public IEnumerable<Movie> Movies { get; set; }
}