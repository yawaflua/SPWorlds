using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class Card : ICard
    {
        public int Balance { get; set; }
        public string Webhook { get; set; }
    }
}
