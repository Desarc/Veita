using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fellesregnskap.App_Code;

namespace Fellesregnskap.Tests.App_Code
{
    /*
    [TestClass]
    public class MongoAccesorTest
    {
        TestData testData;

        [TestInitialize]
        public void CreateTestData()
        {
            MongoAccessor.Connect();
            testData = new TestData();
            testData.CreateTestData();
            testData.InsertTestData();
        }

        [TestCleanup]
        public void CleanDB()
        {
            testData.CleanUpDB();
        }

        [TestMethod]
        public void TestGetReceiptsMonth()
        {
            var receipts1 = MongoAccessor.GetReceiptsByMonth(14, DateTime.Now.Year);
            Assert.AreEqual(2, receipts1.Count);
            var receipts2 = MongoAccessor.GetReceiptsByMonth(DateTime.Now.Month, DateTime.Now.Year);
            Assert.AreEqual(3, receipts2.Count);
        }

        [TestMethod]
        public void TestGetAllReceiptsForParticipantByMonth()
        {
            var participant1 = MongoAccessor.GetParticipant("Arnulf");
            var receipts1 = MongoAccessor.GetAllReceiptsForParticipantByMonth(participant1, 14, DateTime.Now.Year);
            Assert.AreEqual(1, receipts1.Count);
            var participant2 = MongoAccessor.GetParticipant("Annie");
            var receipts2 = MongoAccessor.GetAllReceiptsForParticipantByMonth(participant2, DateTime.Now.Month, DateTime.Now.Year);
            Assert.AreEqual(0, receipts2.Count);
            var participant3 = MongoAccessor.GetParticipant("Abed");
            var receipts3 = MongoAccessor.GetAllReceiptsForParticipantByMonth(participant3, DateTime.Now.Month, DateTime.Now.Year);
            Assert.AreEqual(1, receipts3.Count);
        }

        [TestMethod]
        public void TestGetAllReceiptsForPayerByMonth()
        {
            var payer1 = MongoAccessor.GetParticipant("Arnulf");
            var receipts1 = MongoAccessor.GetAllReceiptsForPayerByMonth(payer1, 14, DateTime.Now.Year);
            Assert.AreEqual(1, receipts1.Count);
            var receipts2 = MongoAccessor.GetAllReceiptsForPayerByMonth(payer1, DateTime.Now.Month, DateTime.Now.Year);
            Assert.AreEqual(2, receipts2.Count);
            var receipts3 = MongoAccessor.GetAllReceiptsForPayerByMonth(payer1, 15, DateTime.Now.Year);
            Assert.AreEqual(0, receipts3.Count);
        }
    }
     * */
}

