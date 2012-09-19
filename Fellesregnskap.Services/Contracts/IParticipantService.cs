using Fellesregnskap.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fellesregnskap.Services
{
    public interface IParticipantService
    {
        // Add
        void AddParticipant(Participant participant);
        
        // Select
        Participant GetParticipant(Guid id);
        IEnumerable<Participant> GetAllParticipants();

        // Delete
        void RemoveParticipant(Guid id);
    }
}
