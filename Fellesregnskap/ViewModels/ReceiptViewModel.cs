using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fellesregnskap.ViewModels
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Pris")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public double Price { get; set; }

        [Display(Name = "Det gjelder")]
        [Required(ErrorMessage = "{0} må være utfylt")]
        public String Description { get; set; }

        [Display(Name = "Dato")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ParticipantViewModel Payer { get; set; }

        [Required]
        public string SelectedParticipantId { get; set; }

        public List<ParticipantViewModel> Participants { get; set; }
    }

}