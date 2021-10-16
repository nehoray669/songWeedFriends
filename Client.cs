using MongoDB.Bson.Serialization.Attributes;
using System;

namespace mongoDb
{
    public class Client
    {
        [BsonId]
        public Guid Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string songName { get; set; }
        public string currTime { get; set; }
    }
}
