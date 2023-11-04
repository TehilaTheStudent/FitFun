using FitFun_Project.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class teachersController : ControllerBase
    {
        private static List<Teacher> _teachers = new List<Teacher> {
            new Teacher { id = 0, age = 25, name = "Malci Katz", phoneNumber = "0556725888", experience = 3  },
                        new Teacher { id = 1, age = 21, name = "Hodaya Avivi", phoneNumber = "0556723568", experience = 1  }

        };
        private static int _id = 2;
       
        // GET: SuperSport/<TeachersController>
        [HttpGet]
        public List<Teacher> Get()
        {
            return _teachers;
        }

        // GET SuperSport/<TeachersController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return _teachers.Find(teachI => teachI.id == id);
        }

        // POST SuperSport/<TeachersController>
        [HttpPost]
        public void Post([FromBody] Teacher newTeacher)
        {
            _teachers.Add(
                new Teacher { id = _id++, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
                );
        }

        // PUT SuperSport/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher newTeacher)
        {
            var deleteTeacher = _teachers.Find(teachI => teachI.id == id);
            _teachers.Remove(deleteTeacher);
            _teachers.Add(
                                new Teacher { id = id, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
);
        }

        // DELETE SuperSport/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteTeacher = _teachers.Find(teachI => teachI.id == id);
            _teachers.Remove(deleteTeacher);

        }
    }
}
