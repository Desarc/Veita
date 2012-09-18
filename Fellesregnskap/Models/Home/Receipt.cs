using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Fellesregnskap.Models.Home
{
    public class Receipt
    {
        public ObjectId Id { get; set; }

        [Display(Name="Pris")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public double Price { get; set; }

        [Display(Name = "Det gjelder")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public String Description { get; set; }

        [Display(Name = "Dato")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public DateTime Date { get; set; }

        [Display(Name = "Måned")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public int Month { get; set; }

        public Participant Payer { get; set; }
        
        public List<Participant> Participants { get; set; }


    }

}