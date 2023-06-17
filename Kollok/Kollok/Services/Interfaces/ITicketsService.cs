using Kollok.Models.Requests;

namespace Kollok.Services.Interfaces;

public interface ITicketsService
{
    public int BuyTickets(BuyTicketRequest request);
}