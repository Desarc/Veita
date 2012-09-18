using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fellesregnskap.Models.Home;
using Fellesregnskap.App_Code;
using MongoDB.Bson;

namespace Fellesregnskap.Tests.App_Code
{
    class TestData
    {
        public List<Receipt> testReceipts1; //betalt av Arnulf
        public List<Receipt> testReceipts2; //Arnulf har deltatt på
        public List<Participant> testParticipants1;
        public List<Participant> testParticipants2;
        public List<Participant> testParticipants3;


        public void CreateTestData()
        {
            var Stig = new Participant { name = "Arnulf" };
            var Magnus = new Participant { name = "Dingo" };
            var Jonas = new Participant { name = "Hodor" };
            var Elisabeth = new Participant { name = "Annie" };
            var Monika = new Participant { name = "Abed" };
            var Oyvin = new Participant { name = "Yussuf" };

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
                date = DateTime.Now,
                month = DateTime.Now.Month,
                payer = Stig,
                description = "test1",
                price = 45.0,
                participants = testParticipants1
            };
            var middag2 = new Receipt
            {
                date = DateTime.Now,
                month = DateTime.Now.Month,
                payer = Stig,
                description = "test2",
                price = 85.0,
                participants = testParticipants3
            };
            var middag3 = new Receipt
            {
                date = DateTime.Now,
                month = 14,
                payer = Monika,
                description = "test3",
                price = 60.0,
                participants = testParticipants1
            };
            var middag4 = new Receipt
            {
                date = DateTime.Now,
                month = DateTime.Now.Month,
                payer = Elisabeth,
                description = "test4",
                price = 90.0,
                participants = testParticipants1
            };
            var middag5 = new Receipt
            {
                date = DateTime.Now,
                month = 14,
                payer = Stig,
                description = "test5",
                price = 65.0,
                participants = testParticipants3
            };

            testReceipts1.Add(middag1);
            testReceipts1.Add(middag2);
            testReceipts1.Add(middag5);

            testReceipts2.Add(middag1);
            testReceipts2.Add(middag3);
            testReceipts2.Add(middag4);

        }

        public void InsertTestData()
        {
            foreach (Participant participant in testParticipants1)
            {
                MongoAccessor.AddParticipant(participant);
            }
            foreach (Participant participant in testParticipants2)
            {
                MongoAccessor.AddParticipant(participant);
            }
            foreach (Participant participant in testParticipants3)
            {
                MongoAccessor.AddParticipant(participant);
            }
            foreach (Receipt receipt in testReceipts1)
            {
                MongoAccessor.AddReceipt(receipt);
            }
            foreach (Receipt receipt in testReceipts2)
            {
                MongoAccessor.AddReceipt(receipt);
            }
        }

        public void CleanUpDB()
        {
            foreach (Participant participant in testParticipants1)
            {
                MongoAccessor.RemoveParticipant(participant.name);
            }
            foreach (Participant participant in testParticipants2)
            {
                MongoAccessor.RemoveParticipant(participant.name);
            }
            foreach (Participant participant in testParticipants3)
            {
                MongoAccessor.RemoveParticipant(participant.name);
            }
            foreach (Receipt receipt in testReceipts1)
            {
                MongoAccessor.RemoveReceipt(receipt.id);
            }
            foreach (Receipt receipt in testReceipts2)
            {
                MongoAccessor.RemoveReceipt(receipt.id);
            }
        }
    }
}
