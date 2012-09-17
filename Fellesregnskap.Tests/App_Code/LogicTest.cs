using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fellesregnskap.Models.Home;
using Fellesregnskap.App_Code;

namespace Fellesregnskap.Tests.App_Code
{
    [TestClass]
    public class LogicTest
    {
        private List<Receipt> testReceipts1; //betalt av Stig
        private List<Receipt> testReceipts2; //Stig har deltatt på
        private List<Participant> testParticipants1;
        private List<Participant> testParticipants2;
        private List<Participant> testParticipants3;

        [TestMethod]
        public void TestCalculateSum()
        {
            createTestData();
            var sum = Logic.CalculateSum(testReceipts1, testReceipts2);
            Assert.AreEqual(-130.0, sum);
           
            
        }

        private void createTestData()
        {
            var Stig = new Participant { name = "Stig" };
            var Magnus = new Participant { name = "Magnus" };
            var Jonas = new Participant { name = "Jonas" };
            var Elisabeth = new Participant { name = "Elisabeth" };
            var Monika = new Participant { name = "Monika" };
            var Oyvin = new Participant { name = "Øyvin" };

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

            var middag1 = new Receipt { 
                date = DateTime.Now, 
                month = DateTime.Now.Month, 
                payer = Stig, 
                description = "test1", 
                price = 45.0, 
                participants = testParticipants1 
            };
            var middag2 = new Receipt { 
                date = DateTime.Now, 
                month = DateTime.Now.Month, 
                payer = Stig, 
                description = "test2", 
                price = 85.0, 
                participants = testParticipants3 
            };
            var middag3 = new Receipt { 
                date = DateTime.Now, 
                month = 14, 
                payer = Monika, 
                description = "test3", 
                price = 60.0, 
                participants = testParticipants1 
            };
            var middag4 = new Receipt { 
                date = DateTime.Now, 
                month = DateTime.Now.Month, 
                payer = Elisabeth, 
                description = "test4", 
                price = 90.0, 
                participants = testParticipants1 
            };
            var middag5 = new Receipt { 
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
    }
}
