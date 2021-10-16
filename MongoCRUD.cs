using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace mongoDb
{
    public class MongoCRUD 
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertUser<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadUsers<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList(); 
        }

        public T LoadUserById<T>(string table, Guid id) 
        {
            var collection = db.GetCollection<T>(table);

            //eq = equal
            var filter = Builders<T>.Filter.Eq("Id", id);

            //returns the first that has an equal id 
            return collection.Find(filter).First();
        }

        //upsert is update or insert
        public void UpsertUser<T>(string table, Guid id, T record) 
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new UpdateOptions { IsUpsert = true });
        }

        public void DeleteUserById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public T GetUserId<T>(string table, string username)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("username", username);
            return collection.Find(filter).First();
        }
    }
}
