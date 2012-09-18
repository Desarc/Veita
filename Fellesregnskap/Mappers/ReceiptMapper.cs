using Fellesregnskap.Models.Common;
using Fellesregnskap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fellesregnskap.Mappers
{
    public class ReceiptMapper
    {
        public static ParticipantsViewModel ModelToViewModel(List<Participant> list)
        {
            return new ParticipantsViewModel
            {
                Participants = list.Select(a => new ParticipantViewModel { Id = a.Id.ToString(), Label = a.Name }).ToList()
            };
        }
    }
}