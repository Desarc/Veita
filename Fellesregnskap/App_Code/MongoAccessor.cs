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
            AddParticipant(receipt.payer);
            foreach(Participant part in receipt.participants)
            {
                AddParticipant(part);
            }
            return receipt.id; //id autogenereres av mongodb
        }

        public static ObjectId AddParticipant(Participant participant)
        {
            var existingPart = GetParticipant(participant.name);
            if (existingPart == null)
            {
                var collection = database.GetCollection<Participant>("Participants");
                collection.Insert(participant);
                return participant.id; //id autogenereres av mongodb
            }
            return existingPart.id;
        }

        public static void AddParticipantToReceipt(Participant participant, Receipt receipt)
        {
            if (receipt.participants.Any(p => p.name == participant.name))
            {
                return;
            }
            receipt.participants.Add(participant);
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
            receipt.participants.Remove(participant);
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
            return allReceipts.Where(receipt => receipt.participants.Any(p => p.name == participant.name)).ToList();
        }

        public static List<Receipt> GetAllReceiptsForPayerByMonth(Participant payer, int month)
        {
            var allReceipts = GetReceiptsByMonth(month);
            return allReceipts.Where(receipt => receipt.payer.name == payer.name).ToList();
        }

        public static void PurgeDB()
        {
            var RecCollection = database.GetCollection<Receipt>("Receipts");
            RecCollection.RemoveAll();
            var PartCollection = database.GetCollection<Participant>("Participants");
            PartCollection.RemoveAll();
        }

        internal static void Connect()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            database = MongoDatabase.Create(connectionstring);
        }
    }
}
