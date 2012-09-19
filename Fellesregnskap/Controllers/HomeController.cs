using Fellesregnskap.App_Code;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fellesregnskap.Mappers;
using Fellesregnskap.Services;
using Fellesregnskap.Services.Contracts;
using Fellesregnskap.Services.Models;

namespace Fellesregnskap.Controllers
{
    public class HomeController : Controller
    {
        IParticipantService _participantservice;
        IReceiptService _receiptService;
        
        public HomeController() : this(new ParticipantService(), new ReceiptService()) { }

        public HomeController(IParticipantService participants, IReceiptService receipts)
        {
            _participantservice = participants;
            _receiptService = receipts;
        }

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
            var viewmodel = ParticipantMappers.ModelToViewModel(new Receipt(), _participantservice.GetAllParticipants());
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddParticipant(Participant participant)
        {
            _participantservice.AddParticipant(participant);
            return RedirectToAction("AddParticipant");
        }

        [HttpPost]
        public ActionResult AddReceipt(Receipt receipt)
        {
            if(ModelState.IsValid && ReceiptValidator.Validate(receipt))
            {
                _receiptService.AddReceipt(receipt);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Errormessage"] = "Noen felter var ikke gyldige";
                return RedirectToAction("AddReceipt");
            }
        }

        [HttpGet]
        public ActionResult RemoveParticipant(Guid Id)
        {
            _participantservice.RemoveParticipant(Id);
            return RedirectToAction("AddParticipant");
        }

        [HttpGet]
        public ActionResult RemoveReceipt(Guid receiptId)
        {
            _receiptService.RemoveReceipt(receiptId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RemoveParticipantFromReceipt(Guid participantId, Guid receiptId)
        {
            _receiptService.RemoveParticipantFromReceipt(participantId, receiptId);
            return RedirectToAction("Index");
        }

        public PartialViewResult ParticipantsList()
        {
            var participants = _participantservice.GetAllParticipants();
            return PartialView("_ParticipantsList", participants);
        }

        public PartialViewResult ParticipantsListForReceipt(Receipt receipt)
        {
            return PartialView("_ParticipantsListDisplay", receipt.Participants);
        }

        public PartialViewResult ReceiptsListCurrentMonth()
        {
            var receipts = _receiptService.GetReceiptsFromMonth(DateTime.Now.Month, DateTime.Now.Year);
            return PartialView("_ReceiptsList", receipts);
        }

        public void CreateTestData()
        {
            List<Receipt> testReceipts1; //betalt av Arnulf
            List<Receipt> testReceipts2; //Arnulf har deltatt på
            List<Participant> testParticipants1;
            List<Participant> testParticipants2;
            List<Participant> testParticipants3;

            var Stig = new Participant { Name = "Arnulf" };
            var Magnus = new Participant { Name = "Dingo" };
            var Jonas = new Participant { Name = "Hodor" };
            var Elisabeth = new Participant { Name = "Annie" };
            var Monika = new Participant { Name = "Abed" };
            var Oyvin = new Participant { Name = "Yussuf" };

            testParticipants1 = new List<Participant>();
            testParticipants2 = new List<Participant>();
            testParticipants3 = new List<Participant>();
            testReceipts1 = new List<Receipt>();
            testReceipts2 = new List<Receipt>();

            testParticipants1.Add(Stig);
            testParticipants1.Add(Magnus);
            testParticipants1.Add(Jonas);

            testParticipants2.Add(Elisabeth);
            testParticipants2.Add(Jonas);
            testParticipants2.Add(Stig);

            testParticipants3.Add(Oyvin);
            testParticipants3.Add(Monika);

            var middag1 = new Receipt
            {
                Date = DateTime.Now,
                Month = DateTime.Now.Month,
                Payer = Stig,
                Description = "test1",
                Price = 45.0,
                Participants = testParticipants1
            };
            var middag2 = new Receipt
            {
                Date = DateTime.Now,
                Month = DateTime.Now.Month,
                Payer = Stig,
                Description = "test2",
                Price = 85.0,
                Participants = testParticipants3
            };
            var middag3 = new Receipt
            {
                Date = DateTime.Now,
                Month = 14,
                Payer = Monika,
                Description = "test3",
                Price = 60.0,
                Participants = testParticipants1
            };
            var middag4 = new Receipt
            {
                Date = DateTime.Now,
                Month = DateTime.Now.Month,
                Payer = Elisabeth,
                Description = "test4",
                Price = 90.0,
                Participants = testParticipants1
            };
            var middag5 = new Receipt
            {
                Date = DateTime.Now,
                Month = 14,
                Payer = Stig,
                Description = "test5",
                Price = 65.0,
                Participants = testParticipants3
            };

            testReceipts1.Add(middag1);
            testReceipts1.Add(middag2);
            testReceipts1.Add(middag5);

            testReceipts2.Add(middag1);
            testReceipts2.Add(middag3);
            testReceipts2.Add(middag4);

            foreach (Participant participant in testParticipants1)
            {
                _participantservice.AddParticipant(participant);
            }
            foreach (Participant participant in testParticipants2)
            {
                _participantservice.AddParticipant(participant);
            }
            foreach (Participant participant in testParticipants3)
            {
                _participantservice.AddParticipant(participant);
            }
            foreach (Receipt receipt in testReceipts1)
            {
                _receiptService.AddReceipt(receipt);
            }
            foreach (Receipt receipt in testReceipts2)
            {
                _receiptService.AddReceipt(receipt);
            }
        }

    }
}
