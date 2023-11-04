using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class participantsController : ControllerBase
    {
        private static List<Participant> _participants = new List<Participant> {
            new Participant { id = 0, name = "Orli Levi", phoneNumber = "0556712345" } ,
             new Participant { id = 1, name = "Tamar Yosef", phoneNumber = "0556718345" },
              new Participant { id = 2, name = "Michal Tzuker", phoneNumber = "0556112345" },
               new Participant { id = 3, name = "Shira Shoham", phoneNumber = "0556712343" }
        };
        private static int _id = 4;
        // GET: api/<ParticipantsController>
        [HttpGet]
        public List<Participant> Get()
        {
            return _participants;
        }

        // GET api/<ParticipantsController>/5
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            return _participants.Find(partI => partI.id == id);
        }


        // POST api/<ParticipantsController>
        [HttpPost]
        public void Post([FromBody] Participant newParticipant)
        {
            _participants.Add(new Participant
            {
                id = _id++,
                name = newParticipant.name,
                phoneNumber = newParticipant.phoneNumber
            });

        }

        // PUT api/<ParticipantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Participant newParticipant)
        {
            var deleteParticipant = _participants.Find(partI => partI.id == id);
            _participants.Remove(deleteParticipant);
            _participants.Add(new Participant
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
            var deleteParticipant = _participants.Find(partI => partI.id == id);
            _participants.Remove(deleteParticipant);
        }
    }
}
