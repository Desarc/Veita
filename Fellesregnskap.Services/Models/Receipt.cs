using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fellesregnskap.Services.Models
{
    public class Receipt
    {
        public String Id { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public int Month { get; set; }
        public Participant Payer { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
