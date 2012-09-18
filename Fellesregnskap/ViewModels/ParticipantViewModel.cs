using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fellesregnskap.ViewModels
{
    public class ParticipantsViewModel
    {
        public List<ParticipantViewModel> Participants { get; set; }
        
        [Required]
        public string SelectedParticipantId { get; set; }
    }

    public class ParticipantViewModel
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }
}