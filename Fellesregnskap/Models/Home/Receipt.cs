using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fellesregnskap.Models.Home
{
    public class Receipt
    {
        public ObjectId id { get; set; }

        [Display(Name="Pris")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public double price { get; set; }

        [Display(Name = "Det gjelder")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public String description { get; set; }

        [Display(Name = "Dato")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public DateTime date { get; set; }

        [Display(Name = "Måned")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public int month { get; set; }

        public Participant payer { get; set; }
        
        public List<Participant> participants { get; set; }


    }

}