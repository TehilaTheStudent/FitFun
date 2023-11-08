using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class lessonsController : ControllerBase
    {

  private readonly DataContext dataContextInstance;
        public lessonsController(DataContext dataContextInstance)
        {
            this.dataContextInstance = dataContextInstance;
        }

<<<<<<< HEAD
       };
        private static int _id = 2;
        [HttpPut("participants/{id}")]
=======
        [HttpPut]
        [Route("participants/{id}")]
>>>>>>> 832fc8192c2979459c8f47df0f7b0d9b61a1f368
        public void PutParticipantIntoLessons(int id,[FromBody] List<int> lessList)
        {
            foreach (var lessI in dataContextInstance.lessonsList)
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
            return dataContextInstance.lessonsList.FindAll(lessI => lessI.teacherId == id);
        }
        [HttpGet("participants/{id}")]
        public List<Lesson> GetLessonsByParticipant(int id)
        {
            return dataContextInstance.lessonsList.FindAll(lessI => lessI.participantsIdList.Exists(partI=>partI==id));
        }

        // GET: SuperSport/<LessonsController>
        [HttpGet]
        public List<Lesson> Get()
        {
            return dataContextInstance.lessonsList;
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
            return dataContextInstance.lessonsList.Find(lessI => lessI.id == id);

        }

        // POST SuperSport/<LessonsController>
        [HttpPost]
        public void Post([FromBody] Lesson newLesson)
        {

            dataContextInstance.lessonsList.Add(new Lesson
            {
                id = dataContextInstance.indexLesson++,
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
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            dataContextInstance.lessonsList.Remove(deleteLesson);
            dataContextInstance.lessonsList.Add(new Lesson { id = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList }
            );
        }

        // DELETE SuperSport/<LessonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            dataContextInstance.lessonsList.Remove(deleteLesson);
        }
    }
}
