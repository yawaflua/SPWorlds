using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class User : IUser
    {
        public string Name { get; }
        public string Uuid { get; }

        public User(string name, string uuid)
        {
            Name = name;
            Uuid = uuid;
        }
    }
}
