using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class teachersController : ControllerBase
    {
      
        private readonly DataContext  dataContextInstance;
        public teachersController(DataContext dataContextInstance)
        {
            this.dataContextInstance = dataContextInstance;
        }


        [HttpGet]
        public List<Teacher> Get()
        {
            return dataContextInstance.teachersList;
        }

        [HttpGet("{id}")]
        public ActionResult< Teacher> Get(int id)
        {
            var res= dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            if (res == null) return StatusCode(404, "teacher id not found in teacher list");
            return res;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Teacher newTeacher)
        {
            if (!validPhone(newTeacher.phoneNumber)) return StatusCode(400, "phone number wrong");

            dataContextInstance.teachersList.Add(
                new Teacher { id = dataContextInstance.indexTeacher, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
                );
            return Ok();
        }
        public bool validPhone(string phone)
        {
            if (phone.Length != 10) return false;
            foreach (int ci in phone)
            {
                if (ci < 48 || ci > 57) return false;
            }
            return true;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher newTeacher)
        {
            if (!validPhone(newTeacher.phoneNumber)) return StatusCode(400, "phone number wrong");

            var deleteTeacher = dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            if (deleteTeacher == null) return StatusCode(404, "teacher id not found in teacher list");

            dataContextInstance.teachersList.Remove(deleteTeacher);
            dataContextInstance.teachersList.Add(
                                new Teacher { id = id, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {//מה עם השיעורים שהיא מלמדת?
            var deleteTeacher = dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            if (deleteTeacher == null) return StatusCode(404, "teacher id not found in teacher list");

            dataContextInstance.teachersList.Remove(deleteTeacher);
            return Ok();

        }
    }
}
