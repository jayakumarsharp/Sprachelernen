using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GermanSprache.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using static GermanSprache.DAL.LanguageDALContext;

namespace GermanSprache.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private IMongoDatabase mongoDatabase;
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient("mongodb+srv://adminuser:123@cluster0-d53ex.mongodb.net");///test?retryWrites=true
            return mongoClient.GetDatabase("test");
        }


        [HttpGet("[action]")]
        public IEnumerable<LanguageDictionaryM> WeatherForecasts()
        {
            using (var db = new LanguageDALContext())
            {
                LanguageDALContext l = new LanguageDALContext();
                // var data = l.All<LanguageDictionaryM>().ToList();
               // insert();
                mongoDatabase = GetMongoDatabase();
                //fetch the details from CustomerDB and pass into view  
                var result = mongoDatabase.GetCollection<LanguageDictionaryM>("myCollection").Find(FilterDefinition<LanguageDictionaryM>.Empty).ToList();
                var blogs = db.LanguageDictionary.ToList();
                return result;
            }
        }



      
    }


    public class mycollection
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string x { get; set; }
    }

    public class LanguageDictionaryM
    {
        [BsonId]
        // external Id, easier to reference: 1,2,3 or A, B, C etc.
        public ObjectId Id { get; set; }

        [BsonElement("English")]
        public string English { get; set; }

        [BsonElement("German")]
        public string German { get; set; }

        [BsonElement("Tamil")]
        public string Tamil { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        
        [BsonDateTimeOptions]
        // attribute to gain control on datetime serialization
        public DateTime UpdatedOn { get; set; } = DateTime.Now;


    }

}
