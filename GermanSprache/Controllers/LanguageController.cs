using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GermanSprache.DAL;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace GermanSprache.Controllers
{

    [Route("api/Language")]
    public class LanguageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        List<Languagedata> lst = new List<Languagedata>();

        private IMongoDatabase mongoDatabase;
        public IMongoDatabase GetMongoDatabase()
        {
            var mongoClient = new MongoClient("mongodb+srv://adminuser:123@cluster0-d53ex.mongodb.net");///test?retryWrites=true
            return mongoClient.GetDatabase("test");
        }


        [HttpPut]
        [Route("Save")]
        public void Save([FromBody] LanguageDictionaryM objLanguage)
        {
            //lst.Add(objLanguage);
            using (var db = new LanguageDALContext())
            {
                var blog = new LanguageDictionary { English = objLanguage.English, German = objLanguage.German, Description = objLanguage.Description, Tamil = objLanguage.Tamil, LastUpdated = DateTime.Now };
                db.LanguageDictionary.Add(blog);
                db.SaveChanges();
            }
            insert(objLanguage);
        }


        public void insert(LanguageDictionaryM lang)
        {
            try
            {
                LanguageDictionaryM cl = new LanguageDictionaryM();
                mongoDatabase = GetMongoDatabase();
                var data = mongoDatabase.GetCollection<LanguageDictionaryM>("myCollection");
                data.InsertOne(lang);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}


public class Languagedata
{
    public string Description { get; set; }
    public string German { get; set; }
    public string English { get; set; }
    public string Tamil { get; set; }

}