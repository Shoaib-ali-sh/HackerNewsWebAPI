using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HackerNewsWebAPI.Tests.Extensions
{
    public static class HttpMessageHandlerExtensions
    {
        public static void SetupRequest(this Mock<HttpMessageHandler> mock, string requestUri, HttpMethod method = null)
        {
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == (method ?? HttpMethod.Get) && req.RequestUri.ToString() == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                });
        }

        public static void SetupRequest(this Mock<HttpMessageHandler> mock, string requestUri, string responseContent, HttpMethod method = null)
        {
            mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                        req.Method == (method ?? HttpMethod.Get) && req.RequestUri.ToString() == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent)
                });
        }
    }
}
