using HackerNewsWebAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsWebAPI.Services;

public class HackerNewsService : IHackerNewsService
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;

    public HackerNewsService(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }

    public async Task<IEnumerable<Story>> GetNewestStoriesAsync()
    {
        if (!_cache.TryGetValue("NewestStories", out IEnumerable<Story> stories))
        {
            var storyIds = await _httpClient.GetFromJsonAsync<int[]>("https://hacker-news.firebaseio.com/v0/newstories.json");
            if (storyIds == null) return Enumerable.Empty<Story>();

            var tasks = storyIds.Take(50).Select(id => _httpClient.GetFromJsonAsync<Story>($"https://hacker-news.firebaseio.com/v0/item/{id}.json"));
            stories = (await Task.WhenAll(tasks)).Where(story => story != null);

            _cache.Set("NewestStories", stories, TimeSpan.FromMinutes(10));
        }

        return stories;
    }
}
