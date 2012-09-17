using Fellesregnskap.Models.Home;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Fellesregnskap.Models
{
    public class MongoAccessor
    {
        private static MongoDatabase database;

        public static void AddReceipt(Receipt receipt)
        {
            var RecCollection = database.GetCollection<Receipt>("Receipts");
            RecCollection.Insert(receipt);
            foreach(Participant part in receipt.participants)
            {
                AddParticipant(part);
            }
        }

        public static void AddParticipant(Participant participant)
        {
            var existingPart = GetParticipant(participant.name);
            if (existingPart == null)
            {
                var collection = database.GetCollection<Participant>("Participants");
                collection.Insert(participant);
            }
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

        internal static void Connect()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            database = MongoDatabase.Create(connectionstring);
        }
    }
}
