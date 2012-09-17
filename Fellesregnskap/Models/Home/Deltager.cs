using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Fellesregnskap.Models.Home
{
    public class Participant
    {
        public ObjectId id { get; set; }
        public String name { get; set; }

        public Participant(String name)
        {
            this.name = name;
        }
            

    }
}
