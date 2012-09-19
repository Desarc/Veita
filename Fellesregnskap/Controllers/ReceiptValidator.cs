using Fellesregnskap.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fellesregnskap.Controllers
{
    public class ReceiptValidator
    {
        public static bool Validate(Receipt receipt)
        {
            return receipt.Participants != null && receipt.Payer != null;
        }
    }
}
