using Fellesregnskap.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services.Contracts
{
    interface IReceiptService
    {
        // Add
        void AddReceipt(Receipt receipt);
        void AddParticipantToReceipt(Receipt receipt, Participant participant);

        // Select
        Receipt GetReceipt(String id);
        IEnumerable<Receipt> GetAllReceipts();
        IEnumerable<Receipt> GetReceiptsFromMonth(int month, int year);
        
        // Delete
        void RemoveReceipt(String id);
        void RemoveParticipantFromReceipt(String id);
    }
}
