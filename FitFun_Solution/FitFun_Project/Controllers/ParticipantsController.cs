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
        
        // GET: api/<ParticipantsController>
        [HttpGet]
        public List<Participant> Get()
        {
            return _interfaceParticipantServiceInstance.Get();
        }

        // GET api/<ParticipantsController>/5
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return _interfaceParticipantServiceInstance.Get(id);
        }


        // POST api/<ParticipantsController>
        [HttpPost]
        public void Post([FromBody] Participant newParticipant)
        {
            _interfaceParticipantServiceInstance.Post(newParticipant);
        }

        // PUT api/<ParticipantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Participant newParticipant)
        {
            _interfaceParticipantServiceInstance.Put(id, newParticipant);
        }

        // DELETE api/<ParticipantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _interfaceParticipantServiceInstance.Delete(id);
        }
    }
}
