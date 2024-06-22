﻿namespace SPWorldsApi.Types.Interfaces
{
    public interface IUserAccount
    {
        public string id { get; set; }
        public string username { get; set; }
        public string minecraftUUID { get; set; }
        public string status { get; set; }
        public List<string> roles { get; set; }
        public ICity city { get; set; }
        public List<IUserCard> cards { get; set; }
        public DateTime createdAt { get; set; }
    }
}
