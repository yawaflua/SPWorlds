using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class UserCard : IUserCard
    {
        public string id { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public int color { get; set; }
    }
}
