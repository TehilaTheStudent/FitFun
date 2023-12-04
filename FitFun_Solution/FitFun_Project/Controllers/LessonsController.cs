using FitFun_Project.Core.Services;//added
using FitFun_Project.Entities;//added

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class lessonsController : ControllerBase
    {

<<<<<<< HEAD
  private readonly InterfaceLessonService _InterfaceLessonServiceInstance;
        public lessonsController(InterfaceLessonService interfaceLessonServiceInstance)
=======
        private readonly DataContext dataContextInstance;
        public lessonsController(DataContext dataContextInstance)
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        {
            this._InterfaceLessonServiceInstance = interfaceLessonServiceInstance;
        }

        [HttpPut("participants/{id}")]
        public ActionResult PutParticipantIntoLessons(int id, [FromBody] List<int> lessList)
        {
<<<<<<< HEAD
            _InterfaceLessonServiceInstance.PutParticipantIntoLessons(id,lessList);
=======
            if (!dataContextInstance.participantsList.Exists(partI => partI.id == id)) return StatusCode(404, "id not exists in participnats");
            foreach (var lessI in dataContextInstance.lessonsList)
            {//participant not signed and  wants to sign
                if (!lessI.participantsIdList.Exists(partI => partI == id) && lessList.Exists(lessId => lessId == lessI.id))
                {
                    if (!isColliding(id, lessI.startHour, lessI.endHour, 0))
                        lessI.participantsIdList.Add(id);
                    else return StatusCode(400,"collision in hours lesson you want to sign ");

                }
                //participant  signed and doesnt want to sign
                if (lessI.participantsIdList.Exists(partI => partI == id) && !lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Remove(id);
            }
            return Ok();
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        [HttpGet("teachers/{id}")]
        public ActionResult<List<Lesson>> GetLessonsByTeacher(int id)
        {
<<<<<<< HEAD
            return _InterfaceLessonServiceInstance.GetLessonsByTeacher(id);
=======
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
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }
        [HttpGet]
        public List<Lesson> Get(int startH, int endH)
        {
<<<<<<< HEAD
            return _InterfaceLessonServiceInstance.GetLessonsByParticipant(id);
        }

        // GET: SuperSport/<LessonsController>
        [HttpGet]
        public List<Lesson> Get()
        {
            return _InterfaceLessonServiceInstance.Get();
        }

        //[HttpGet]

        //public List<Lesson> GetHoursRange([FromQuery] int startH, [FromQuery] int endH)
        //{
        //    if (_lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH).Count != 0)
        //        return _lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH);
        //    return null;
        //}
        // GET SuperSport/<LessonsController>/5
=======
            return dataContextInstance.lessonsList.Where(lessI => (lessI.startHour.Hour >= startH || startH == null) && (lessI.endHour.Hour <= endH || endH == null)).ToList();

        }
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        [HttpGet("{id}")]
        public ActionResult< Lesson> Get(int id)
        {
<<<<<<< HEAD
            return _InterfaceLessonServiceInstance.Get(id);

=======
           var res= dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (res == null)
                return StatusCode(404, "lesson id not found in lessons");
            return res;
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        [HttpPost]
        public ActionResult Post([FromBody] Lesson newLesson)
        {
<<<<<<< HEAD

            _InterfaceLessonServiceInstance.Post(newLesson);
=======
            //האם לעשות בדיקות תקינות?
            //על השעות המשתתפות והמורות
            if (!validLesson(newLesson.startHour, newLesson.endHour,newLesson.teacherId,newLesson.participantsIdList))
                return StatusCode(400,"problem with new lesson details");
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
            return Ok();
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson newLesson)
        {
<<<<<<< HEAD
            _InterfaceLessonServiceInstance.Put(id, newLesson);
=======
    //check also?
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (deleteLesson == null)
                return StatusCode(404, "lesson id not found in lessons");
            if (!validLesson(newLesson.startHour, newLesson.endHour, newLesson.teacherId, newLesson.participantsIdList))
                return StatusCode(400, "problem with lesson derails");
            dataContextInstance.lessonsList.Remove(deleteLesson);
            dataContextInstance.lessonsList.Add(new Lesson { id = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList });
            return Ok();
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
<<<<<<< HEAD
            _InterfaceLessonServiceInstance.Delete(id);
=======
            var deleteLesson = dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            if (deleteLesson == null) return StatusCode(404, "lesson id not found in lessons");
            dataContextInstance.lessonsList.Remove(deleteLesson);
            return Ok();
        }

        public bool validHours(DateTime startH,DateTime endH)
        {
            if ((endH - startH).TotalMinutes >= 30 && (endH - startH).TotalMinutes <= 120)
                return true;
            return false;
        }
        public bool isColliding(int id, DateTime startH, DateTime endH,int status)
        {
           
            //participant=0 teacher=1
            if (status == 0)
            {
                List<Lesson> lessonsPrt = GetLessonsByParticipant(id).Value;
                if (lessonsPrt.Exists(lessI => lessI.startHour.Day == startH.Day && (startH.TimeOfDay >= lessI.startHour.TimeOfDay && startH.TimeOfDay < lessI.endHour.TimeOfDay) || (endH.TimeOfDay > lessI.startHour.TimeOfDay && endH.TimeOfDay <= lessI.endHour.TimeOfDay)))
                    return true;
                return false;
            }

                List<Lesson> lessonsList = GetLessonsByTeacher(id).Value;
                if (lessonsList.Exists(lessI => lessI.startHour.Day == startH.Day && (startH.TimeOfDay >= lessI.startHour.TimeOfDay && startH.TimeOfDay < lessI.endHour.TimeOfDay) || (endH.TimeOfDay > lessI.startHour.TimeOfDay && endH.TimeOfDay <= lessI.endHour.TimeOfDay)))
                    return false;
                return true;
            }
      
        public bool  validLesson(DateTime startH, DateTime endH, int teacherId, List<int> participsnts)
        {
            //טווח שעות הגיוני, השעות אותו יום, המורה לא מלמדת בשיעור באותו זמן, המשתתפות לא משתתפות באותו זמן בשיעור אחר
            if (!validHours(startH, endH)) return false;
            if (isColliding(teacherId, startH, endH, 1))return false;
            if(participsnts.Exists(idPart=>isColliding(idPart,startH,endH,0 )))return false;
            return true;
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98
        }
    }
}
