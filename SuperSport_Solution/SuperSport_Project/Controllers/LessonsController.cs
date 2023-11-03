using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperSport_Project.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperSportProject.Controllers
{
    [Route("SuperSport/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        
       private static List<Lesson> _lessons = new List<Lesson>
       {
           new Lesson
           {
               id =_id, type = "power dance", price = 35, startHour = new DateTime(), endHour = new DateTime(), teacherId = 0, participantsIdList = new List<int>()
           }
       };
       private static int _id = 1;
        // GET: SuperSport/<LessonsController>
      [HttpGet]
        public List<Lesson> Get()
        {
            return _lessons;
        }

        //[HttpGet]
     
        //public List<Lesson> GetHoursRange([FromQuery] int startH, [FromQuery] int endH)
        //{
        //    if (_lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH).Count != 0)
        //        return _lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH);
        //    return null;
        //}
        // GET SuperSport/<LessonsController>/5
        [HttpGet("{id}")]
        public Lesson Get(int id)
        {
            return _lessons.Find(lessI => lessI.id == id);

        }

        // POST SuperSport/<LessonsController>
        [HttpPost]
        public void Post([FromBody] Lesson newLesson)
        {
            
            _lessons.Add(new Lesson
            {
                id = _id++,
                type = newLesson.type,
                price = newLesson.price,
                startHour = newLesson.startHour,
                endHour = newLesson.endHour,
                teacherId = newLesson.teacherId,
                participantsIdList = newLesson.participantsIdList

            });
        }

        // PUT SuperSport/<LessonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lesson newLesson)
        {
            var deleteLesson = _lessons.Find(lessI => lessI.id == id);
            _lessons.Remove(deleteLesson);
        _lessons.Add(    new Lesson { id = _id++, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList }
        );
        }

        // DELETE SuperSport/<LessonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteLesson = _lessons.Find(lessI => lessI.id == id);
            _lessons.Remove(deleteLesson);
        }
    }
}
