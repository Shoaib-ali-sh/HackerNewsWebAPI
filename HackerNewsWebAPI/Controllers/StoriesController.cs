using HackerNewsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoriesController : ControllerBase
{
    private readonly IHackerNewsService _service;
    public StoriesController(IHackerNewsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetNewestStories()
    {
        return Ok(await _service.GetNewestStoriesAsync());
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchStories([FromQuery] string query)
    {
        var stories = await _service.GetNewestStoriesAsync();
        return Ok(stories.Where(s => s.Title?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false));
    }
}
