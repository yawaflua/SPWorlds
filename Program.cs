using SPWorldsApi.HttpClient;
using SPWorldsApi.Payments;
using SPWorldsApi.Users;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace SPWorldsApi
{
    public sealed class SPWorlds : IPaymentWrapper, IUserWrapper
    {
        internal string token { get; }
        public HttpRequest client { get; set; }
        string BASE_URL { get; set; } = "https://spworlds.ru/api/public";
        AuthenticationHeaderValue AuthHeader { get; set; }

        public SPWorlds(string id, string token)
        {
            var BearerToken = $"{id}:{token}";
            this.token = token;
            string Base64BearerToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(BearerToken));

            AuthHeader = new("Bearer", Base64BearerToken);
            client = new(BASE_URL, AuthHeader);
        }

        /// <summary>
        /// Validating wenhook from site
        /// </summary>
        /// <param name="requestBody">Body of request</param>
        /// <param name="base64Hash">X-Body-Hash</param>
        /// <returns></returns>
        public bool ValidateWebhook(string requestBody, string base64Hash)
        {
            byte[] requestData = Encoding.UTF8.GetBytes(requestBody);

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(token)))
            {
                byte[] hashBytes = hmac.ComputeHash(requestData);

                string computedHash = Convert.ToBase64String(hashBytes);

                return base64Hash.Equals(computedHash);
            }
        }
    }
}
