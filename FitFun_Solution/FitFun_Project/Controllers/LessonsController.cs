using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class lessonsController : ControllerBase
    {

        private static List<Lesson> _lessons = new List<Lesson>
       {
           new Lesson
           {
               id =0, type = "power dance", price = 35, startHour = new DateTime(), endHour = new DateTime(), teacherId = 0, participantsIdList = new List<int>{0,1,2}
           },
           new Lesson
           {
               id =1, type = "pilates", price = 39, startHour = new DateTime(), endHour = new DateTime(), teacherId = 1, participantsIdList = new List<int>{1,2,3}
           }

       };
        private static int _id = 2;
        [HttpPut("participants/{id}")]
        public void PutParticipantIntoLessons(int id,[FromBody] List<int> lessList)
        {
            foreach (var lessI in _lessons)
            {//participant not signed and  wants to sign
                if (!lessI.participantsIdList.Exists(partI => partI == id) && lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Add(id);
                //participant  signed and doesnt want to sign
                    if (lessI.participantsIdList.Exists(partI => partI == id) && !lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Remove(id);
            }
        }

        [HttpGet("teachers/{id}")]
        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _lessons.FindAll(lessI => lessI.teacherId == id);
        }
        [HttpGet("participants/{id}")]
        public List<Lesson> GetLessonsByParticipant(int id)
        {
            return _lessons.FindAll(lessI => lessI.participantsIdList.Exists(partI=>partI==id));
        }

        // GET: SuperSport/<LessonsController>
        [HttpGet]
        public List<Lesson> Get()
        {
            return _lessons;
        }

        [HttpGet("hours")]

        public List<Lesson> GetHoursRange(int startH,int endH)
        {
            if (_lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH).Count != 0)
                return _lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH);
            return null;
        }
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
            _lessons.Add(new Lesson { id = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList }
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
