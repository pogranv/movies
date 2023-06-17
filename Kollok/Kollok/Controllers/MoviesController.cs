using Kollok.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers;

[ApiController]
[Route("api/v1/movies")]
public class ActivityController : ControllerBase
{
    private readonly IMoviesService _moviesService;

    public ActivityController(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    /// <summary>
    /// Получает информацию о всех фильмах.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(_moviesService.GetMovies());
    }
}