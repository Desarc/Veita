using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fellesregnskap.Models.Home
{
    public class Participant
    {
        public ObjectId Id { get; set; }
        
        [Required]
        public string Navn { get; set; }
    }
}
