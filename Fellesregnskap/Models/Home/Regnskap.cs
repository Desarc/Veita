using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Fellesregnskap.Models.Home
{
    public class Receipt
    {
        public ObjectId Id { get; set; }
        public double Pris { get; set; }
        public Participant Betaler { get; set; }
        public List<Participant> Deltagere { get; set; }
    }
}