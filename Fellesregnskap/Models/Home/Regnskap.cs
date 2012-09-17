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
        public Participant betaler { get; set; }
        public DateTime date { get; set; }
        public int month { get; set; }
        public List<Participant> participants { get; set; }

        public Receipt()
        {
            date = DateTime.Now;
            month = date.Month;
        }
    }

}