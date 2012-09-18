﻿using Fellesregnskap.Models.Common;
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

        public ActionResult AddParticipant()
        {
            return View();
        }

        public ActionResult AddReceipt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddParticipant(Participant participant)
        {
            MongoAccessor.AddParticipant(participant);
            return RedirectToAction("AddParticipant");
        }

        public PartialViewResult ParticipantsList()
        {
            var participants = MongoAccessor.GetAllParticipants();
            return PartialView("_ParticipantsList", participants);
        }

        private List<double> CreateSumVector(int month)
        {
            var sumVector = new List<double>();
            var participants = MongoAccessor.GetAllParticipants();
            foreach (Participant participant in participants)
            {
                var payerReceipts = MongoAccessor.GetAllReceiptsForPayerByMonth(participant, month);
                var participantReceipts = MongoAccessor.GetAllReceiptsForParticipantByMonth(participant, month);
                var sum = Logic.CalculateSum(payerReceipts, participantReceipts);
                sumVector.Add(sum);
            }
            return sumVector;
        }
    }
}
