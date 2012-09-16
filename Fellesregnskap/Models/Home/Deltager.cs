using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace Fellesregnskap.Models.Home
{
    public class Participant
    {
        public ObjectId Id { get; set; }
        public string Navn { get; set; }
    }
}
