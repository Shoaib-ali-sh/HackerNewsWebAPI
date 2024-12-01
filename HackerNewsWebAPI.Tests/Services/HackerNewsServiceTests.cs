using HackerNewsWebAPI.Models;
using HackerNewsWebAPI.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace HackerNewsWebAPI.Tests.Services
{
    public class HackerNewsServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly HackerNewsService _service;

        public HackerNewsServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/")
            };
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _service = new HackerNewsService(_httpClient, _memoryCache);
        }

        [Fact]
        public async Task GetNewestStoriesAsync_ReturnsStories()
        {
            // Arrange
            var storyIds = new[] { 1, 2 };
            var stories = new[]
            {
                new Story { Title = "Story 1", Url = "https://example.com/story1" },
                new Story { Title = "Story 2", Url = "https://example.com/story2" }
            };

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri!.ToString() == "https://hacker-news.firebaseio.com/v0/newstories.json"),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(storyIds))
                });

            foreach (var storyId in storyIds)
            {
                var storyResponse = stories[storyId - 1];
                _httpMessageHandlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.Is<HttpRequestMessage>(req =>
                            req.Method == HttpMethod.Get &&
                            req.RequestUri!.ToString() == $"https://hacker-news.firebaseio.com/v0/item/{storyId}.json"),
                        ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonSerializer.Serialize(storyResponse))
                    });
            }

            // Act
            var result = await _service.GetNewestStoriesAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Story 1", result.First().Title);
            Assert.Equal("Story 2", result.Last().Title);
        }
    }
}
