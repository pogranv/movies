using Kollok.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers;

[ApiController]
[Route("api/v1/showtimes")]
public class ShowtimesController : ControllerBase
{
    private readonly IShowtimesService _showtimesService;

    public ShowtimesController(IShowtimesService showtimesService)
    {
        _showtimesService = showtimesService;
    }

    /// <summary>
    /// Получает информацию о сеансах.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetShowtimes()
    {
        var response = _showtimesService.GetShowtimes();
        return Ok(response);
    }
}