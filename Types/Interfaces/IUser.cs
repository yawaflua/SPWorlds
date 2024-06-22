using SPWorldsApi.Types.Enums;
using SPWorldsApi.Types.Models;
using System.Text.Json.Nodes;

namespace SPWorldsApi.Types.Interfaces
{
    public interface IUser
    {
        public string Name { get; }
        public string Uuid { get; }


        public static async Task<IUser> CreateUserAsync(string name)
        {
            string? uuid;
            using (System.Net.Http.HttpClient client = new())
            {
                uuid = (string?)JsonNode.Parse(await client.GetStringAsync($"https://api.mojang.com/users/profiles/minecraft/{name}"))["id"];
            }
            User user = new(name, uuid);
            return user;
        }

        public string GetSkinPart(SkinPart skinPart, string size = "64")
        {
            return (string)$"https://avatar.spworlds.ru/{skinPart}/{size}/{Name}";
        }
    }
}
