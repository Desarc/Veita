using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Fellesregnskap.Models.Home
{
    public class Receipt
    {
        public ObjectId id { get; set; }
        public double price { get; set; }
        public String description { get; set; }
        public Participant payer { get; set; }
        public DateTime date { get; set; }
        public int month { get; set; }
        public List<Participant> participants { get; set; }


    }

}