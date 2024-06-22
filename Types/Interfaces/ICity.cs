namespace SPWorldsApi.Types.Interfaces
{
    public interface ICity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int x { get; set; }
        public int z { get; set; }
        public bool isMayor { get; set; }
    }
}
