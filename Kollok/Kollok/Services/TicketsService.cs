using Kollok.Models.Requests;
using Kollok.Services.Exceptions;
using Kollok.Services.Interfaces;

namespace Kollok.Services;

public class TicketsService : ITicketsService
{
    private readonly IDbService _dbService;

    public TicketsService(IDbService dbService)
    {
        _dbService = dbService;
    }

    public int BuyTickets(BuyTicketRequest request)
    {
        return _dbService.BuyTickets(request.SessionId, request.Count);
    }
}