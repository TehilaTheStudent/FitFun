using FitFun_Project.Core.Services;//added
using FitFun_Project.Entities;//added
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class participantsController : ControllerBase
    {
      private readonly InterfaceParticipantService _interfaceParticipantServiceInstance;
            public participantsController(InterfaceParticipantService interfaceParticipantServiceInstance)
        {
            this._interfaceParticipantServiceInstance = interfaceParticipantServiceInstance;
        }
        
        [HttpGet]
        public List<Participant> Get()
        {
            return _interfaceParticipantServiceInstance.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Participant> Get(int id)
        {
<<<<<<< HEAD
            return _interfaceParticipantServiceInstance.Get(id);
=======
            var res= dataContextInstance.participantsList.Find(partI => partI.id == id);
            if (res == null) return StatusCode(404, "participant id not found in participants");
            return res;
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }


        [HttpPost]
        public ActionResult Post([FromBody] Participant newParticipant)
        {
<<<<<<< HEAD
            _interfaceParticipantServiceInstance.Post(newParticipant);
=======
            if (!validPhone(newParticipant.phoneNumber)) return StatusCode(400, "phone number wrong");

            dataContextInstance.participantsList.Add(new Participant
            {
                id = dataContextInstance.indexParticipant++,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });
            return Ok();

>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        public bool validPhone(string phone)
        {
<<<<<<< HEAD
            _interfaceParticipantServiceInstance.Put(id, newParticipant);
=======
            if (phone.Length != 10) return false;
            foreach (int ci in phone)
            {
                if (ci < 48 || ci > 57) return false;
            }
            return true;
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Participant newParticipant)
        {
            if (!validPhone(newParticipant.phoneNumber)) return StatusCode(400, "phone number wrong");
            var deleteParticipant = dataContextInstance.participantsList.Find(partI => partI.id == id);
            if (deleteParticipant == null) return StatusCode(404, "participant id not found in participants");
            dataContextInstance.participantsList.Remove(deleteParticipant);
            dataContextInstance.participantsList.Add(new Participant
            {
                id = id,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });
            return Ok();

>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
<<<<<<< HEAD
            _interfaceParticipantServiceInstance.Delete(id);
=======
            //לבטל רישום לשיעורים
            var deleteParticipant = dataContextInstance.participantsList.Find(partI => partI.id == id);
            if (deleteParticipant == null) return StatusCode(404, "participant id not found in participants");
            dataContextInstance.participantsList.Remove(deleteParticipant);
            return Ok();
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }
    }
}
