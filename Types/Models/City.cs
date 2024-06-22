using SPWorldsApi.Types.Interfaces;

namespace SPWorldsApi.Types.Models
{
    internal class City : ICity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int x { get; set; }
        public int z { get; set; }
        public bool isMayor { get; set; }
    }
}
