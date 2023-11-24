using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Core.Services;//added
using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Service.Services
{
    
    public class ParticipantService:InterfaceParticipantService
    {
        private readonly InterfaceParticipantRepository _interfaceParticipantRepositoryInstance;
        public ParticipantService(InterfaceParticipantRepository interfaceParticipantRepositoryInstance)
        {
            _interfaceParticipantRepositoryInstance = interfaceParticipantRepositoryInstance;
        }

        public void Delete(int id)
        {
            _interfaceParticipantRepositoryInstance.Delete(id);
        }

        public List<Participant> Get()
        {
          return  _interfaceParticipantRepositoryInstance.Get();
        }

        public Participant Get(int id)
        {
          return _interfaceParticipantRepositoryInstance.Get(id);
        }

        public void Post(Participant newParticipant)
        {
            _interfaceParticipantRepositoryInstance.Post(newParticipant);   
        }

        public void Put(int id, Participant newParticipant)
        {
            _interfaceParticipantRepositoryInstance.Put(id, newParticipant);
        }
    }
}
