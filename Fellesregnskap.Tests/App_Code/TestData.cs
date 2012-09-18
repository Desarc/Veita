using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fellesregnskap.Models.Common;
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
                MongoAccessor.RemoveParticipant(participant.Name);
            }
            foreach (Participant participant in testParticipants2)
            {
                MongoAccessor.RemoveParticipant(participant.Name);
            }
            foreach (Participant participant in testParticipants3)
            {
                MongoAccessor.RemoveParticipant(participant.Name);
            }
            foreach (Receipt receipt in testReceipts1)
            {
                MongoAccessor.RemoveReceipt(receipt.Id);
            }
            foreach (Receipt receipt in testReceipts2)
            {
                MongoAccessor.RemoveReceipt(receipt.Id);
            }
        }
    }
}
