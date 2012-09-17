﻿using Fellesregnskap.Models.Home;
using Fellesregnskap.App_Code;
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(Participant participant)
        {
            MongoAccessor.AddParticipant(participant);
            return RedirectToAction("Index");
        }

        public PartialViewResult ParticipantsList()
        {
            var participants = MongoAccessor.GetAllParticipants();
            return PartialView("_ParticipantsList", participants);
        }
    }
}
