using Fellesregnskap.Models.Home;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Fellesregnskap.Models
{
    public class MongoAccessor
    {
        public static List<Participant> GetParticipants()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            var database = MongoDatabase.Create(connectionstring);
            var collection = database.GetCollection<Participant>("Participants");

            return collection.FindAll().ToList();
        }

        public static List<Receipt> GetReceipts()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            var database = MongoDatabase.Create(connectionstring);
            var collection = database.GetCollection<Receipt>("Receipts");

            return collection.FindAll().ToList();
        }

    }
}
