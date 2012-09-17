using Fellesregnskap.Models;
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
            var part = new Participant("Stig");
            //MongoAccessor.AddParticipant(part);
            var rec = new Receipt();
            rec.id = new MongoDB.Bson.ObjectId();
            rec.participants = new List<Participant>();
            rec.participants.Add(part);
            MongoAccessor.AddReceipt(rec);
            var testGetRec = MongoAccessor.GetReceipt(rec.id);
            var parts = testGetRec.participants;

            MongoAccessor.RemoveReceipt(rec.id);
            testGetRec = MongoAccessor.GetReceipt(rec.id);
            var testPart = MongoAccessor.GetParticipant("Stig");
            var testGetRecsByMonth = MongoAccessor.GetReceiptsByMonth(9);
            //var testRec = testGetRecsByMonth.First<Receipt>();
            var testGetPart = MongoAccessor.GetAllParticipants();
            MongoAccessor.RemoveParticipant("Stig");
            testGetPart = MongoAccessor.GetAllParticipants();
            return View();
        }

    }
}
