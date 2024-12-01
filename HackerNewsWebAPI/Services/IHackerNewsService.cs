using HackerNewsWebAPI.Models;

namespace HackerNewsWebAPI.Services;

public interface IHackerNewsService
{
    Task<IEnumerable<Story>> GetNewestStoriesAsync();
}
