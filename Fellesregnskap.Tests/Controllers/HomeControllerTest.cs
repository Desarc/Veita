using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fellesregnskap;
using Fellesregnskap.Controllers;

namespace Fellesregnskap.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        /*
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
         * 
         * 
            var testGetRecsByMonth = MongoAccessor.GetReceiptsByMonth(9);
            MongoAccessor.RemoveReceipt(rec.id);
            testGetRec = MongoAccessor.GetReceipt(rec.id);
            var testPart = MongoAccessor.GetParticipant("Stig");
            //var testRec = testGetRecsByMonth.First<Receipt>();
            var testGetPart = MongoAccessor.GetAllParticipants();
            MongoAccessor.RemoveParticipant("Stig");
            testGetPart = MongoAccessor.GetAllParticipants();
         */


    }
}
