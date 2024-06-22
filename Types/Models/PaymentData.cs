using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class PaymentData : IPaymentData
    {
        public IPaymentItems[] Items { get; set; }
        public string RedirectUrl { get; set; }
        public string WebHookUrl { get; set; }
        public string Data { get; set; }
    }
}
