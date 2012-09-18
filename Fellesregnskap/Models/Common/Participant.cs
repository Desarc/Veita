using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fellesregnskap.Models.Common
{
    public class Participant
    {
        public ObjectId Id { get; set; }
        [Required]
        public String Name { get; set; }
    }
}
