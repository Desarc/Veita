using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fellesregnskap.Models.Home;

namespace Fellesregnskap.ViewModels
{
    public class ParticipantBalance
    {
        public double Balance { get; set; }
        public Participant Participant { get; set; }
    }
}