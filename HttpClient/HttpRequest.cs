using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPWorldsApi.HttpClient
{
    public class HttpRequest(string BASE_URL, AuthenticationHeaderValue AuthHeader)
    {
        internal async Task<string> SendRequest(string endpoint, HttpMethod method = null, object body = null)
        {
            method ??= body == null ? HttpMethod.Get : HttpMethod.Post;

            HttpResponseMessage message;
            var client = new System.Net.Http.HttpClient();

            using (var requestMessage = new HttpRequestMessage(method, BASE_URL + endpoint))
            {
                requestMessage.Content = new StringContent(
                    JsonSerializer.Serialize(body),
                    Encoding.UTF8, "application/json"
                );

                requestMessage.Headers.Authorization = AuthHeader;

                message = await client.SendAsync(requestMessage);

            }

            client.Dispose();

            return await message.Content.ReadAsStringAsync();
        }
    }

}
