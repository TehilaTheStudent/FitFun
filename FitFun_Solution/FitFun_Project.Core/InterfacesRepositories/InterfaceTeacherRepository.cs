using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Core.Repositories
{
    public interface InterfaceTeacherRepository
    {
        List<Teacher> Get();
        public Teacher Get(int id);
        void Post(Teacher newTeacher);
        void Put(int id, Teacher newTeacher);
        void Delete(int id);
    }
}
