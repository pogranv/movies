using Kollok.Models.Requests;
using Kollok.Services.Exceptions;
using Kollok.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers;

[ApiController]
[Route("api/v1/tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketsService _ticketsService;

    public TicketsController(ITicketsService ticketsService)
    {
        _ticketsService = ticketsService;
    }

    /// <summary>
    /// Осуществляет покупку билетов.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult BuyTickets(BuyTicketRequest request)
    {
        try
        {
            var availableTickets = _ticketsService.BuyTickets(request);
            return Ok(new {availableTickets = availableTickets});
        }
        catch (NotEnoughTicketsException ex)
        {
            return BadRequest(new { code = 400, message = ex.Message });
        }
    }
}