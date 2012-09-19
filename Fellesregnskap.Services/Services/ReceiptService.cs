using Fellesregnskap.Services.Contracts;
using Fellesregnskap.Services.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services
{
    public class ReceiptService : IReceiptService
    {
        private MongoDatabase _database;
        private MongoCollection<Receipt> _collection;

        public ReceiptService()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            _database = MongoDatabase.Create(connectionstring);
            _collection = _database.GetCollection<Receipt>("Receipts");
        }

        public void AddReceipt(Receipt receipt)
        {
            _collection.Insert(receipt);
        }

        public void AddParticipantToReceipt(Receipt receipt, Participant participant)
        {
            throw new NotImplementedException();
        }

        public Receipt GetReceipt(Guid id)
        {
            return _collection.FindOneById(id);
        }

        public IEnumerable<Receipt> GetAllReceipts()
        {
            return _collection.FindAll().AsEnumerable();
        }

        public IEnumerable<Receipt> GetReceiptsFromMonth(int month, int year)
        {

            var allReceipts = _collection.FindAll();
            return allReceipts.Where(receipt => receipt.Date.Year == year && receipt.Date.Month == month).ToList();
            /*
            return _collection
                .AsQueryable<Receipt>()
                .Where(receipt => receipt.Date.Year == year && receipt.Date.Month == month)
                .ToList();*/
        }

        public void RemoveReceipt(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveParticipantFromReceipt(Guid participantid, Guid receiptid)
        {
            throw new NotImplementedException();
        }
    }

}
