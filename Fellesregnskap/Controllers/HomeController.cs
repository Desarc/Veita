﻿using Fellesregnskap.Models;
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
<<<<<<< HEAD
            var participants = MongoAccessor.GetParticipants(/* middagsid */);
=======
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            MongoAccessor.PurgeDB();
            var part = new Participant("Stig");
            var part2 = new Participant("Magnus");
            //MongoAccessor.AddParticipant(part);
            var rec = new Receipt();
            rec.id = new MongoDB.Bson.ObjectId();
            rec.participants = new List<Participant>();
            rec.participants.Add(part);
            var testList = new List<Participant>();
            testList.Add(part2);
            var rec2 = new Receipt(50.0, "test", part, testList);
            MongoAccessor.AddReceipt(rec2);
            var rec3 = new Receipt(20.0, "test2", part, testList);
            MongoAccessor.AddReceipt(rec3);
            var testId = MongoAccessor.AddReceipt(rec);
            var testGetRec = MongoAccessor.GetReceipt(rec.id);
            var parts = testGetRec.participants;
            var recForPart = MongoAccessor.GetAllReceiptsForParticipantByMonth(part2, 9);
>>>>>>> e75b568c8b3d3ebe8dc1d70f57fe03c79df3e1f0

            
            var testGetRecsByMonth = MongoAccessor.GetReceiptsByMonth(9);
            MongoAccessor.RemoveReceipt(rec.id);
            testGetRec = MongoAccessor.GetReceipt(rec.id);
            var testPart = MongoAccessor.GetParticipant("Stig");
            //var testRec = testGetRecsByMonth.First<Receipt>();
            var testGetPart = MongoAccessor.GetAllParticipants();
            MongoAccessor.RemoveParticipant("Stig");
            testGetPart = MongoAccessor.GetAllParticipants();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Participant participant)
        {

            return RedirectToAction("ParticipantCreated");
        }

        public PartialViewResult ParticipantsList()
        {
            var participants = new List<Participant>(); 
            return PartialView("_ParticipantsList", participants);
        }
    }
}
