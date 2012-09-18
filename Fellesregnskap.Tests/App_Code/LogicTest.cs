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

        [TestMethod]
        public void TestCalculateSum()
        {
            var testData = new TestData();
            testData.CreateTestData();
            var sum = Logic.CalculateSum(testData.testReceipts1, testData.testReceipts2);
            Assert.AreEqual(-130.0, sum);
           
            
        }
    }
}
