using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fellesregnskap.Models.Common;
using Fellesregnskap.App_Code;

namespace Fellesregnskap.ViewModels
{
    public class ParticipantBalanceViewModel
    {
        public double Balance { get; set; }
        public Participant Participant { get; set; }

        private List<double> CreateSumVector(int month, int year)
        {
            var sumVector = new List<double>();
            var participants = MongoAccessor.GetAllParticipants();
            foreach (Participant participant in participants)
            {
                var payerReceipts = MongoAccessor.GetAllReceiptsForPayerByMonth(participant, month, year);
                var participantReceipts = MongoAccessor.GetAllReceiptsForParticipantByMonth(participant, month, year);
                var sum = Logic.CalculateSum(payerReceipts, participantReceipts);
                sumVector.Add(sum);
            }
            return sumVector;
        }
    }
}