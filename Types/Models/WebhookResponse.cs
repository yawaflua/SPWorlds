using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class WebhookResponse : IWebhookResponse
    {
        public int Id { get; set; }
        public string Webhook { get; set; }
    }
}
