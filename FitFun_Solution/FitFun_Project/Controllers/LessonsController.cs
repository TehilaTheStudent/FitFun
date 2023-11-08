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

        [HttpPut("participants/{id}")]
        public ActionResult PutParticipantIntoLessons(int id, [FromBody] List<int> lessList)
        {
            if (!dataContextInstance.participantsList.Exists(partI => partI.id == id)) return StatusCode(404, "id not exists in participnats");
            foreach (var lessI in dataContextInstance.lessonsList)
            {//participant not signed and  wants to sign
                if (!lessI.participantsIdList.Exists(partI => partI == id) && lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Add(id);
                //participant  signed and doesnt want to sign
                if (lessI.participantsIdList.Exists(partI => partI == id) && !lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Remove(id);
            }
            return Ok();
        }

        [HttpGet("teachers/{id}")]
        public ActionResult<List<Lesson>> GetLessonsByTeacher(int id)
        {
            List<Lesson> res= dataContextInstance.lessonsList.FindAll(lessI => lessI.teacherId == id);
            if (res.Count == 0) return StatusCode(404, "teacher id not found in lesson list");
            return res;
        }
  
        [HttpGet("participants/{id}")]
        public ActionResult<List<Lesson>> GetLessonsByParticipant(int id)
        {
            List<Lesson> res = dataContextInstance.lessonsList.FindAll(lessI => lessI.participantsIdList.Exists(partI => partI == id));
            if (res.Count == 0) return StatusCode(404, "participant id not found in lessons' participant list");
            return res;
        }
        [HttpGet]
        public List<Lesson> Get(int startH, int endH)
        {
            return dataContextInstance.lessonsList.Where(lessI => (lessI.startHour.Hour >= startH || startH == null) && (lessI.endHour.Hour <= endH || endH == null)).ToList();

        }
        [HttpGet("{id}")]
        public ActionResult< Lesson> Get(int id)
        {
           var res= dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (res == null)
                return StatusCode(404, "lesson id not found in lessons");
            return res;
        }

        [HttpPost]
        public void Post([FromBody] Lesson newLesson)
        {
            //האם לעשות בדיקות תקינות?
           //על השעות המשתתפות והמורות
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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson newLesson)
        {
    //check also?
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (deleteLesson == null)
                return StatusCode(404, "lesson id not found in lessons");
            dataContextInstance.lessonsList.Remove(deleteLesson);
            dataContextInstance.lessonsList.Add(new Lesson { id = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList });
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (deleteLesson == null) return StatusCode(404, "lesson id not found in lessons");
            dataContextInstance.lessonsList.Remove(deleteLesson);
            return Ok();
        }
    }
}
