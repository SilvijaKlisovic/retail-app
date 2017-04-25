using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace RetailApp.Misc
{
    public class Logger
    {
        private IMongoDatabase db;

        public Logger()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            MongoClient client = null;
            try
            {
                client = new MongoClient(settings);
                this.db = client.GetDatabase("Loogs");
                var collection = db.GetCollection<Loog>("Info");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public IMongoCollection<Loog> Loggs
        {
            get
            {
                return db.GetCollection<Loog>("Info");
            }
        }
    }

    public class Loog
    {
        public string type { get; set; }
        public string Message { get; set; }
        public string dateTime { get; set; }          
    }
}