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
<<<<<<< HEAD
        public ObjectId Id { get; set; }
        
        [Required]
        public string Navn { get; set; }
=======
        public ObjectId id { get; set; }
        public String name { get; set; }

        public Participant(String name)
        {
            this.name = name;
        }
            

>>>>>>> e75b568c8b3d3ebe8dc1d70f57fe03c79df3e1f0
    }
}
