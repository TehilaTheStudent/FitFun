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

        [HttpPut]
        [Route("participants/{id}")]
        public void PutParticipantIntoLessons(int id,[FromBody] List<int> lessList)
        {
            _InterfaceLessonServiceInstance.PutParticipantIntoLessons(id,lessList);
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _InterfaceLessonServiceInstance.GetLessonsByTeacher(id);
        }
        [HttpGet]
        [Route("participants/{id}")]
        public List<Lesson> GetLessonsByParticipant(int id)
        {
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
        [HttpGet("{id}")]
        public Lesson Get(int id)
        {
            return _InterfaceLessonServiceInstance.Get(id);

        }

        // POST SuperSport/<LessonsController>
        [HttpPost]
        public void Post([FromBody] Lesson newLesson)
        {

            _InterfaceLessonServiceInstance.Post(newLesson);
        }

        // PUT SuperSport/<LessonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Lesson newLesson)
        {
            _InterfaceLessonServiceInstance.Put(id, newLesson);
        }

        // DELETE SuperSport/<LessonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _InterfaceLessonServiceInstance.Delete(id);
        }
    }
}
