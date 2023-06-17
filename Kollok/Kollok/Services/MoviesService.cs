using Kollok.Models.Responses;
using Kollok.Services.Interfaces;

namespace Kollok.Services;

public class MoviesService : IMoviesService
{
    private readonly IDbService _dbService;
    
    public MoviesService(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    public GetMoviesRespose GetMovies()
    {
        var movies = _dbService.GetMovies();
        return new GetMoviesRespose
        {
            Movies = movies
        };
    }
}