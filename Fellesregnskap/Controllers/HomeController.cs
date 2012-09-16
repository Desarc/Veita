using Fellesregnskap.Models.Home;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fellesregnskap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            var database = MongoDatabase.Create(connectionstring);
            var collection = database.GetCollection<Deltager>("Thingies");

            collection.Insert(new Deltager { Navn = "Jonas" });

            var deltagere = collection.FindAll();

            return View();
        }
    }
}
