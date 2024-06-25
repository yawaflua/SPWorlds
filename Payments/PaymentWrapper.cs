using SPWorldsApi.Types.Interfaces;
using SPWorldsApi.Utils;
using System.Text.Json;
using System.Text.Json.Nodes;
using SPWorldsApi.Users;

namespace SPWorldsApi.Payments
{
    public class PaymentWrapper : UserWrapper
    {
        HttpClient.HttpRequest client { get; set; }

        internal async Task<string> SendRequest(string endpoint, HttpMethod method = null, object body = null)
        {
            return await client.SendRequest(endpoint, method, body);  
        }

        /// <summary>
        /// Get card from spworlds
        /// </summary>
        /// <returns></returns>
        public async Task<ICard> GetCard()
        => (await SendRequest("card")).Deserialize<ICard>();

        /// <summary>
        /// Create transaction
        /// </summary>
        /// <param name="receiver">receiver card</param>
        /// <param name="amount">amount of AR</param>
        /// <param name="comment">comment to transaction</param>
        /// <returns>balance of card</returns>
        public async Task<int> CreateTransaction(string receiver, int amount, string comment)
        {
            var transitionInfo = new Dictionary<string, object>
        {
            { "receiver", receiver },
            { "amount", amount },
            { "comment", comment }
        };

            var response = JsonNode.Parse(await SendRequest(endpoint: "transactions", body: transitionInfo));
            return (int)response["balance"];
        }

        public async Task<string> InitPayment(IPaymentItems[] items, string redirectUrl, string webhookUrl, string data)
        {
            var paymentInfo = new Dictionary<string, object>
        {
            { "items", JsonSerializer.Serialize(items).ToLower()},
            { "redirectUrl", redirectUrl },
            { "webhookUrl", webhookUrl },
            { "data", data }
        };

            var payment = JsonObject.Parse(await SendRequest(endpoint: $"payment", body: paymentInfo));
            var url = payment["url"];

            return (string)url;
        }

        /// <summary>
        /// Create payment url
        /// </summary>
        /// <param name="paymentData"></param>
        /// <returns></returns>
        public async Task<string> InitPayment(IPaymentData paymentData)
        {
            var payment = JsonObject.Parse(await SendRequest(endpoint: $"payment", body: JsonSerializer.Serialize(paymentData)));
            return (string)payment["url"];
        }

    }
}
