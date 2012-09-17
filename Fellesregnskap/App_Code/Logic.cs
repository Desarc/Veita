using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fellesregnskap.Models.Home;

namespace Fellesregnskap.App_Code
{
    public class Logic
    {
        public static double CalculateSum(List<Receipt> payerReceipts, List<Receipt> participantReceipts)
        {
            double sum = 0.0;
            foreach(Receipt receipt in payerReceipts)
            {
                sum -= receipt.price;
            }
            foreach (Receipt receipt in participantReceipts)
            {
                sum += receipt.price / receipt.participants.Count;
            }
            return sum;
        }

    }

}