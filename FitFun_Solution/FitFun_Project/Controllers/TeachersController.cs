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
        public void Post([FromBody] Teacher newTeacher)
        {
            dataContextInstance.teachersList.Add(
                new Teacher { id = dataContextInstance.indexTeacher, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
                );
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher newTeacher)
        {
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
        {
            var deleteTeacher = dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            if (deleteTeacher == null) return StatusCode(404, "teacher id not found in teacher list");

            dataContextInstance.teachersList.Remove(deleteTeacher);
            return Ok();

        }
    }
}
