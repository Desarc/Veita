using Fellesregnskap.Services.Models;
using Fellesregnskap.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fellesregnskap.Mappers
{
    public class ParticipantMappers
    {
        public static ReceiptViewModel ModelToViewModel(Receipt receipt, IEnumerable<Participant> list)
        {
            return new ReceiptViewModel
            {
                Date = receipt.Date,
                Description = receipt.Description,
                Id = receipt.Id.ToString(),
                Price = receipt.Price,
                Payer = new ParticipantViewModel (),
                Participants = list.Select(a => new ParticipantViewModel { Id = a.Id.ToString(), Name = a.Name }).ToList()
            };
        }
    }
}