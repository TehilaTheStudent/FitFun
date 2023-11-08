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


        // GET: SuperSport/<TeachersController>
        [HttpGet]
        public List<Teacher> Get()
        {
            return dataContextInstance.teachersList;
        }

        // GET SuperSport/<TeachersController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return dataContextInstance.teachersList.Find(teachI => teachI.id == id);
        }

        // POST SuperSport/<TeachersController>
        [HttpPost]
        public void Post([FromBody] Teacher newTeacher)
        {
            dataContextInstance.teachersList.Add(
                new Teacher { id = dataContextInstance.indexTeacher, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
                );
        }

        // PUT SuperSport/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher newTeacher)
        {
            var deleteTeacher = dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            dataContextInstance.teachersList.Remove(deleteTeacher);
            dataContextInstance.teachersList.Add(
                                new Teacher { id = id, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
);
        }

        // DELETE SuperSport/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteTeacher = dataContextInstance.teachersList.Find(teachI => teachI.id == id);
            dataContextInstance.teachersList.Remove(deleteTeacher);

        }
    }
}
