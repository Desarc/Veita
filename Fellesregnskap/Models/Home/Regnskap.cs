using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;


namespace Fellesregnskap.Models.Home
{
    public class Regnskap
    {
        public ObjectId Id { get; set; }
        public double Pris { get; set; }
        public string Betaler { get; set; }
        public List<Deltager> Deltagere { get; set; }
    }
}