using SPWorldsApi.Types.Interfaces;
using SPWorldsApi.Types.Models;
using SPWorldsApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SPWorldsApi.Users
{
    internal interface IUserWrapper
    {
        HttpClient.HttpRequest client { get; set; }
        internal async Task<string> SendRequest(string endpoint, HttpMethod method = null, object body = null)
        {
            return await client.SendRequest(endpoint, method, body);
        }

        /// <summary>
        /// Get user cards by nickname
        /// </summary>
        /// <param name="username">Username of player</param>
        /// <returns>Array of cards</returns>
        public async Task<IUserCard[]> GetUserCardsAsync(string username)
        => (await SendRequest($"accounts/{username}/cards")).Deserialize<IUserCard[]>();

        /// <summary>
        /// Get user info from site
        /// </summary>
        /// <param name="discordId">Discord id of user</param>
        /// <returns></returns>
        public async Task<IUser> GetUser(string discordId)
        => (await SendRequest($"users/{discordId}")).Deserialize<IUser>();

        public async Task<IUserAccount> GetMeAsync()
        => (await SendRequest("accounts/me")).Deserialize<IUserAccount>();

        /// <summary>
        /// Setting up a webhook to card
        /// </summary>
        /// <param name="webhookUrl">Url of webhook</param>
        /// <returns></returns>
        public async Task<IWebhookResponse> SetWebhook(string webhookUrl)
            => (await SendRequest("card/webhook", HttpMethod.Put, @$"{{ ""url"": ""{webhookUrl}"" }}")).Deserialize<IWebhookResponse>();

    }
}
