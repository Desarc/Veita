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
            var participants = MongoAccessor.GetParticipants(/* middagsid */);

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
