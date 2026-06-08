
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace PortfolioFrontend.Auth
{
    public class CustomHttpHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;

        public CustomHttpHandler(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", cancellationToken, "authToken");

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
