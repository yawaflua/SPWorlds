namespace SPWorldsApi.Types.Interfaces
{
    public interface IPaymentItems
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string? Comment { get; set; }
    }
}
