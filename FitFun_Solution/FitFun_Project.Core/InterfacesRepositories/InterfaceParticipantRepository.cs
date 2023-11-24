using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Core.Repositories
{
    public interface InterfaceParticipantRepository
    {
        List<Participant> Get();
        Participant Get(int id);
        void Post( Participant newParticipant);
        void Put(int id, Participant newParticipant);
        void Delete(int id);
    }
}
