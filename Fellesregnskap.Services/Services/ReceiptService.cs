using Fellesregnskap.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services.Services
{
    public class ReceiptService : IReceiptService
    {
        public void AddReceipt(Models.Receipt receipt)
        {
            throw new NotImplementedException();
        }

        public void AddParticipantToReceipt(Models.Receipt receipt, Models.Participant participant)
        {
            throw new NotImplementedException();
        }

        public Models.Receipt GetReceipt(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Receipt> GetAllReceipts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Receipt> GetReceiptsFromMonth(int month, int year)
        {
            throw new NotImplementedException();
        }

        public void RemoveReceipt(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipantFromReceipt(string id)
        {
            throw new NotImplementedException();
        }
    }
}
