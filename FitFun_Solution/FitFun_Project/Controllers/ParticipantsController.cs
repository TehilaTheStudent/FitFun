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
        
        // GET: api/<ParticipantsController>
        [HttpGet]
        public List<Participant> Get()
        {
            return dataContextInstance.participantsList;
        }

        // GET api/<ParticipantsController>/5
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return dataContextInstance.participantsList.Find(partI => partI.id == id);
        }


        // POST api/<ParticipantsController>
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

        // PUT api/<ParticipantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Participant newParticipant)
        {
            var deleteParticipant = dataContextInstance.participantsList.Find(partI => partI.id == id);
            dataContextInstance.participantsList.Remove(deleteParticipant);
            dataContextInstance.participantsList.Add(new Participant
            {
                id = id,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });

        }

        // DELETE api/<ParticipantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteParticipant = dataContextInstance.participantsList.Find(partI => partI.id == id);
            dataContextInstance.participantsList.Remove(deleteParticipant);
        }
    }
}
