using System.Net.Http;
using System.Threading.Tasks;

namespace Mepost.Helpers
{
    public static class ApiHelper
    {
        public static async Task<HttpResponseMessage> SendRequestAsync(HttpClient client, HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url);
            if (content != null)
            {
                request.Content = content;
            }

            return await client.SendAsync(request);
        }
    }
}
