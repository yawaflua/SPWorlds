using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    public class PaymentItems : IPaymentItems
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string? Comment { get; set; } = null;
    }
}
