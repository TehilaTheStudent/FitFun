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

        private readonly InterfaceLessonService _InterfaceLessonServiceInstance;
        public lessonsController(InterfaceLessonService interfaceLessonServiceInstance)
        {
            this._InterfaceLessonServiceInstance = interfaceLessonServiceInstance;
        }

         [HttpPut("participants/{id}")]
        public ActionResult PutParticipantIntoLessons(int id, [FromBody] List<int> lessList)
        {
            _InterfaceLessonServiceInstance.PutParticipantIntoLessons(id, lessList);

            return Ok();
        }

          [HttpGet("teachers/{id}")]
        public ActionResult<List<Lesson>> GetLessonsByTeacher(int id)
        {
            return _InterfaceLessonServiceInstance.GetLessonsByTeacher(id);

        }

        [HttpGet("participants/{id}")]
        public ActionResult<List<Lesson>> GetLessonsByParticipant(int id)
        {
            return _InterfaceLessonServiceInstance.GetLessonsByParticipant(id);
        }

          [HttpGet]
        public List<Lesson> Get(int startH, int endH)
        {
            return _InterfaceLessonServiceInstance.Get();
        }



        

          [HttpGet("{id}")]
        public ActionResult<Lesson> Get(int id)
        {
            return _InterfaceLessonServiceInstance.Get(id);


        }

        [HttpPost]
        public ActionResult Post([FromBody] Lesson newLesson)
        {

            _InterfaceLessonServiceInstance.Post(newLesson);

            return Ok();
        }

          [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Lesson newLesson)
        {
            _InterfaceLessonServiceInstance.Put(id, newLesson);
            return Ok();
        }

           [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _InterfaceLessonServiceInstance.Delete(id);

            return Ok();
        }

        //public bool validHours(DateTime startH,DateTime endH)
        //{
        //    if ((endH - startH).TotalMinutes >= 30 && (endH - startH).TotalMinutes <= 120)
        //        return true;
        //    return false;
        //}
        //public bool isColliding(int id, DateTime startH, DateTime endH,int status)
        //{

        //    //participant=0 teacher=1
        //    if (status == 0)
        //    {
        //        List<Lesson> lessonsPrt = GetLessonsByParticipant(id).Value;
        //        if (lessonsPrt.Exists(lessI => lessI.startHour.Day == startH.Day && (startH.TimeOfDay >= lessI.startHour.TimeOfDay && startH.TimeOfDay < lessI.endHour.TimeOfDay) || (endH.TimeOfDay > lessI.startHour.TimeOfDay && endH.TimeOfDay <= lessI.endHour.TimeOfDay)))
        //            return true;
        //        return false;
        //    }

        //        List<Lesson> lessonsList = GetLessonsByTeacher(id).Value;
        //        if (lessonsList.Exists(lessI => lessI.startHour.Day == startH.Day && (startH.TimeOfDay >= lessI.startHour.TimeOfDay && startH.TimeOfDay < lessI.endHour.TimeOfDay) || (endH.TimeOfDay > lessI.startHour.TimeOfDay && endH.TimeOfDay <= lessI.endHour.TimeOfDay)))
        //            return false;
        //        return true;
        //    }

        //public bool  validLesson(DateTime startH, DateTime endH, int teacherId, List<int> participsnts)
        //{
        //    //טווח שעות הגיוני, השעות אותו יום, המורה לא מלמדת בשיעור באותו זמן, המשתתפות לא משתתפות באותו זמן בשיעור אחר
        //    if (!validHours(startH, endH)) return false;
        //    if (isColliding(teacherId, startH, endH, 1))return false;
        //    if(participsnts.Exists(idPart=>isColliding(idPart,startH,endH,0 )))return false;
        //    return true;
        //}
    }
}
