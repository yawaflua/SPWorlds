namespace SPWorldsApi.Types.Interfaces
{
    public interface IPaymentData
    {
        public IPaymentItems[] Items { get; set; }
        public string RedirectUrl { get; set; }
        public string WebHookUrl { get; set; }
        public string Data { get; set; }
    }
}
