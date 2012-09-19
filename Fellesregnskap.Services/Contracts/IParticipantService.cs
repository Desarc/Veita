using Fellesregnskap.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fellesregnskap.Services
{
    interface IParticipantService
    {
        // Add
        void AddParticipant(Participant participant);
        
        // Select
        Participant GetParticipant(String id);
        IEnumerable<Participant> GetAllParticipant();

        // Delete
        void RemoveParticipant(String id);
    }
}
