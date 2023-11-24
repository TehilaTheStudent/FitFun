using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Data.Rpositories
{
    public class ParticipantRepository:InterfaceParticipantRepository
    {
        private readonly DataContext _dataContextInstance;
        public ParticipantRepository(DataContext dataContextInstance)
        {
            this._dataContextInstance = dataContextInstance;
        }

     
        public List<Participant> Get()
        {
            return _dataContextInstance.participantsList;
        }

    
        public Participant Get(int id)
        {
            return _dataContextInstance.participantsList.Find(partI => partI.id == id);
        }



        public void Post( Participant newParticipant)
        {
            _dataContextInstance.participantsList.Add(new Participant
            {
                id = _dataContextInstance.indexParticipant++,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });

        }

        public void Put(int id, Participant newParticipant)
        {
            var deleteParticipant = _dataContextInstance.participantsList.Find(partI => partI.id == id);
            _dataContextInstance.participantsList.Remove(deleteParticipant);
            _dataContextInstance.participantsList.Add(new Participant
            {
                id = id,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });

        }

        public void Delete(int id)
        {
            var deleteParticipant = _dataContextInstance.participantsList.Find(partI => partI.id == id);
            _dataContextInstance.participantsList.Remove(deleteParticipant);
        }
    }
}
