using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class participantsController : ControllerBase
    {
      private readonly DataContext dataContextInstance;
            public participantsController(DataContext dataContextInstance)
        {
            this.dataContextInstance = dataContextInstance;
        }
        
        [HttpGet]
        public List<Participant> Get()
        {
            return dataContextInstance.participantsList;
        }

        [HttpGet("{id}")]
        public ActionResult<Participant> Get(int id)
        {
            var res= dataContextInstance.participantsList.Find(partI => partI.id == id);
            if (res == null) return StatusCode(404, "participant id not found in participants");
            return res;
        }


        [HttpPost]
        public void Post([FromBody] Participant newParticipant)
        {
            dataContextInstance.participantsList.Add(new Participant
            {
                id = dataContextInstance.indexParticipant++,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Participant newParticipant)
        {
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

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var deleteParticipant = dataContextInstance.participantsList.Find(partI => partI.id == id);
            if (deleteParticipant == null) return StatusCode(404, "participant id not found in participants");
            dataContextInstance.participantsList.Remove(deleteParticipant);
            return Ok();
        }
    }
}
