using Fellesregnskap.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fellesregnskap.App_Code
{
    public class Logic
    {
        public static double CalculateSum(List<Receipt> payerReceipts, List<Receipt> participantReceipts)
        {
            double sum = 0.0;
            foreach(Receipt receipt in payerReceipts)
            {
                sum -= receipt.Price;
            }
            foreach (Receipt receipt in participantReceipts)
            {
                sum += receipt.Price / receipt.Participants.Count;
            }
            return sum;
        }

    }

}