using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fellesregnskap.App_Code;

namespace Fellesregnskap.ViewModels
{
    public class ParticipantBalanceViewModel
    {
        public double Balance { get; set; }
        public ParticipantViewModel Participant { get; set; }
    }
}