using Fellesregnskap.Services.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services
{
    public class ParticipantService : IParticipantService
    {
        private MongoDatabase _database;
        private MongoCollection<Participant> _collection;

        public ParticipantService()
        {
            var connectionstring = ConfigurationManager.AppSettings.Get("MONGOHQ_URL");
            _database = MongoDatabase.Create(connectionstring);
            _collection = _database.GetCollection<Participant>("Participants");
        }

        public void AddParticipant(Participant participant)
        {
            if (!ParticipantExists(participant))
            {
                _collection.Insert(participant);
            }
        }

        public Participant GetParticipant(Guid id)
        {
            var query = Query.EQ("_id", id);
            return _collection.FindOne(query);
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            return _collection.FindAll().ToList();
        }

        public void RemoveParticipant(Guid id)
        {
            var query = Query.EQ("_id", id);
            _collection.Remove(query);
        }
        
        private bool ParticipantExists(Participant participant)
        {
            var query = Query.EQ("Name", participant.Name);
            return _collection.FindOne(query) != null;
        }
    }
}
