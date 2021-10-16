using MongoDB.Bson.Serialization.Attributes;
using System;

namespace mongoDb
{
    public class Client
    {
        public Client()
        {
        }

        public Client(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.isLobbyOpen = false;
        }

        [BsonId]
        public Guid Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string songName { get; set; }
        public string currTime { get; set; }
        public bool isLobbyOpen { get; set; }
    }
}
