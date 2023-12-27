using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Data.Rpositories
{
    public class TeacherRepository:InterfaceTeacherRepository
    {
        private readonly DataContext _dataContextInstance;
        public TeacherRepository(DataContext dataContextInstance)
        {
            this._dataContextInstance = dataContextInstance;
        }


    
        public List<Teacher> Get()
        {
            return _dataContextInstance.teachersData.ToList<Teacher>();
        }

      
        public Teacher Get(int id)
        {
            return _dataContextInstance.teachersData.ToList<Teacher>().Find(teachI => teachI.ID == id);
        }

    
        public void Post( Teacher newTeacher)
        {
            _dataContextInstance.teachersData.ToList<Teacher>().Add(
                new Teacher { ID = _dataContextInstance.indexTeacher, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
                );
        }

    
        public void Put(int id,  Teacher newTeacher)
        {
            var deleteTeacher = _dataContextInstance.teachersData.ToList<Teacher>().Find(teachI => teachI.ID == id);
            _dataContextInstance.teachersData.ToList<Teacher>().Remove(deleteTeacher);
            _dataContextInstance.teachersData.ToList<Teacher>().Add(
                                new Teacher { ID = id, experience = newTeacher.experience, phoneNumber = newTeacher.phoneNumber, age = newTeacher.age, name = newTeacher.name }
);
        }

    
        public void Delete(int id)
        {
            var deleteTeacher = _dataContextInstance.teachersData.ToList<Teacher>().Find(teachI => teachI.ID == id);
            _dataContextInstance.teachersData.ToList<Teacher>().Remove(deleteTeacher);

        }
    }
}
