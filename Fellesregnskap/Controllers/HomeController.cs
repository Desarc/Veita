﻿using Fellesregnskap.Models.Common;
using Fellesregnskap.App_Code;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fellesregnskap.Mappers;

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
            ViewBag.Errormessage = TempData["Errormessage"];
            return View();
        }

        [HttpPost]
        public ActionResult AddParticipant(Participant participant)
        {
            MongoAccessor.AddParticipant(participant);
            return RedirectToAction("AddParticipant");
        }

        [HttpPost]
        public ActionResult AddReceipt(Receipt receipt)
        {
            if(ModelState.IsValid && ReceiptValidator.Validate(receipt))
            {
                MongoAccessor.AddReceipt(receipt);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Errormessage"] = "Noen felter var ikke gyldige";
                return RedirectToAction("AddReceipt");
            }
        }

        [HttpGet]
        public ActionResult RemoveParticipant(string id)
        {
            MongoAccessor.RemoveParticipant(id);
            return RedirectToAction("AddParticipant");
        }

        public PartialViewResult ParticipantsList()
        {
            var participants = MongoAccessor.GetAllParticipants();
            return PartialView("_ParticipantsList", participants);
        }

        public PartialViewResult ReceiptsList()
        {
            var receipts = MongoAccessor.GetReceiptsByMonth(DateTime.Now.Month, DateTime.Now.Year);
            return PartialView("_ReceiptsList", receipts);
        }

        public PartialViewResult ParticipantSelecter()
        {
            var viewdata = ReceiptMapper.ModelToViewModel(MongoAccessor.GetAllParticipants());
            return PartialView("ParticipantSelecter", viewdata);
        }
    }
}
