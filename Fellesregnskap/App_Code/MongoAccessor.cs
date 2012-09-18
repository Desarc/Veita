using Fellesregnskap.Models.Home;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Fellesregnskap.App_Code
{
    public class MongoAccessor
    {
        private static MongoDatabase database;

        public static ObjectId AddReceipt(Receipt receipt)
        {
            var RecCollection = database.GetCollection<Receipt>("Receipts");
            RecCollection.Insert(receipt);
            AddParticipant(receipt.Payer);
            foreach(Participant part in receipt.Participants)
            {
                AddParticipant(part);
            }
            return receipt.Id; //id autogenereres av mongodb
        }

        public static ObjectId AddParticipant(Participant participant)
        {
            var existingPart = GetParticipant(participant.Name);
            if (existingPart == null)
            {
                var collection = database.GetCollection<Participant>("Participants");
                collection.Insert(participant);
                return participant.Id; //id autogenereres av mongodb
            }
            return existingPart.Id;
        }

        public static void AddParticipantToReceipt(Participant participant, Receipt receipt)
        {
            if (receipt.Participants.Any(p => p.Name == participant.Name))
            {
                return;
            }
            receipt.Participants.Add(participant);
            AddParticipant(participant);
            var collection = database.GetCollection<Receipt>("Receipts");
            collection.Save(receipt);
        }

        public static void UpdateReceipt(Receipt receipt)
        {
            var collection = database.GetCollection<Receipt>("Receipts");
            collection.Save(receipt);
        }

        public static void RemoveParticipantFromReceipt(Participant participant, Receipt receipt)
        {
            receipt.Participants.Remove(participant);
            var collection = database.GetCollection<Receipt>("Receipts");
            collection.Save(receipt);
        }

        public static void RemoveReceipt(ObjectId receiptId)
        {
            var collection = database.GetCollection<Receipt>("Receipts");
            var query = Query.EQ("_id", receiptId);
            collection.Remove(query);
        }

        public static void RemoveParticipant(String name)
        {
            var collection = database.GetCollection<Participant>("Participants");
            var query = Query.EQ("name", name);
            collection.Remove(query);
        }

        public static Participant GetParticipant(String name)
        {
            var collection = database.GetCollection<Participant>("Participants");
            var query = Query.EQ("name", name);
            return collection.FindOne(query);
        }

        public static Receipt GetReceipt(ObjectId receiptId)
        {
            var collection = database.GetCollection<Receipt>("Receipts");
            var query = Query.EQ("_id", receiptId);
            return collection.FindOne(query);
        }

        public static List<Receipt> GetReceiptsByMonth(int month)
        {
            var collection = database.GetCollection<Receipt>("Receipts");
            var query = Query.EQ("month", month);
            return collection.Find(query).ToList();
        }

        public static List<Participant> GetAllParticipants()
        {
            var collection = database.GetCollection<Participant>("Participants");
            return collection.FindAll().ToList();
        }

        public static List<Receipt> GetAllReceiptsForParticipantByMonth(Participant participant, int month)
        {
            var allReceipts = GetReceiptsByMonth(month);
            return allReceipts.Where(receipt => receipt.Participants.Any(p => p.Name == participant.Name)).ToList();
        }

        public static List<Receipt> GetAllReceiptsForPayerByMonth(Participant payer, int month)
        {
            var allReceipts = GetReceiptsByMonth(month);
            return allReceipts.Where(receipt => receipt.Payer.Name == payer.Name).ToList();
        }

        public static void PurgeDB()
        {
            var RecCollection = database.GetCollection<Receipt>("Receipts");
            RecCollection.RemoveAll();
            var PartCollection = database.GetCollection<Participant>("Participants");
            PartCollection.RemoveAll();
        }

        public static void Connect()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            database = MongoDatabase.Create(connectionstring);
        }
    }
}
