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

        private readonly InterfaceTeacherService _interfaceTeacherServiceInstance;
        public teachersController(InterfaceTeacherService interfaceTeacherServiceInstance)
        {
            this._interfaceTeacherServiceInstance = interfaceTeacherServiceInstance;
        }


        [HttpGet]
        public List<Teacher> Get()
        {
            return _interfaceTeacherServiceInstance.Get();
        }

           [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            return _interfaceTeacherServiceInstance.Get(id);
           
        }

        [HttpPost]
        public ActionResult Post([FromBody] Teacher newTeacher)
        {
            _interfaceTeacherServiceInstance.Post(newTeacher);
          
            return Ok();
        }


         [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Teacher newTeacher)
        {
            _interfaceTeacherServiceInstance.Put(id, newTeacher);
            return Ok();
        }

         [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _interfaceTeacherServiceInstance.Delete(id);
        }
    }
}
