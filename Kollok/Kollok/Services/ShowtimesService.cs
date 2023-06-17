using Kollok.Models.Responses;
using Kollok.Services.Interfaces;

namespace Kollok.Services;

public class ShowtimesService : IShowtimesService
{
    private readonly IDbService _dbService;

    public ShowtimesService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public GetShowtimesResponse GetShowtimes()
    {
        var showtimes = _dbService.GetShowtimes();
        return new GetShowtimesResponse
        {
            Showtimes = showtimes
        };
    }
}