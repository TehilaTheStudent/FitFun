using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Core.Services;//added
using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Service.Services
{
    public class TeacherService : InterfaceTeacherService
    {
        private readonly InterfaceTeacherRepository _interfaceTeacherRepositoryInstance;
        public TeacherService(InterfaceTeacherRepository interfaceTeacherRepositoryInstance)
        {
            _interfaceTeacherRepositoryInstance = interfaceTeacherRepositoryInstance;
        }

        public void Delete(int id)
        {
            _interfaceTeacherRepositoryInstance.Delete(id);
        }

        public List<Teacher> Get()
        {
            return _interfaceTeacherRepositoryInstance.Get();
        }

        public Teacher Get(int id)
        {
            return _interfaceTeacherRepositoryInstance.Get(id);
        }

        public void Post(Teacher newParticipant)
        {
            _interfaceTeacherRepositoryInstance.Post(newParticipant);
        }

        public void Put(int id, Teacher newParticipant)
        {
            _interfaceTeacherRepositoryInstance.Put(id, newParticipant);
        }
    }
}
