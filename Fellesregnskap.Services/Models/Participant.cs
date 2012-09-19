using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services.Models
{
   public class Participant
    {
       public Participant()
       {
           Id = new Guid();
       }

       [BsonId]
        public Guid Id { get; set; }
        public String Name { get; set; }
    }
}

