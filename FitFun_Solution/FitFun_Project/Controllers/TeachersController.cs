using FitFun_Project.Core.Services;//added
using FitFun_Project.Entities;//added
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitFun_Project.Controllers
{
    [Route("FitFun/[controller]")]
    [ApiController]
    public class teachersController : ControllerBase
    {
      
        private readonly InterfaceTeacherService  _interfaceTeacherServiceInstance;
        public teachersController(InterfaceTeacherService interfaceTeacherServiceInstance)
        {
            this._interfaceTeacherServiceInstance = interfaceTeacherServiceInstance;
        }


        // GET: SuperSport/<TeachersController>
        [HttpGet]
        public List<Teacher> Get()
        {
            return _interfaceTeacherServiceInstance.Get();
        }

        // GET SuperSport/<TeachersController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return _interfaceTeacherServiceInstance.Get(id);
        }

        // POST SuperSport/<TeachersController>
        [HttpPost]
        public void Post([FromBody] Teacher newTeacher)
        {
            _interfaceTeacherServiceInstance.Post(newTeacher);
        }

        // PUT SuperSport/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher newTeacher)
        {
            _interfaceTeacherServiceInstance.Put(id,newTeacher);
        }

        // DELETE SuperSport/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _interfaceTeacherServiceInstance.Delete(id);

        }
    }
}
