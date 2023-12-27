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
            return _interfaceParticipantServiceInstance.Get(id);


        }


        [HttpPost]
        public ActionResult Post([FromBody] Participant newParticipant)
        {
            _interfaceParticipantServiceInstance.Post(newParticipant);


            return Ok();

        }

    
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Participant newParticipant)
        {
            _interfaceParticipantServiceInstance.Put(id, newParticipant);

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _interfaceParticipantServiceInstance.Delete(id);

            return Ok();
        }
     
    }
}

