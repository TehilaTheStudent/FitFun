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
    public class LessonService:InterfaceLessonService
    {
        private readonly InterfaceLessonRepository _interfaceLessonRepositoryInstance;
        public LessonService(InterfaceLessonRepository interfaceLessonRepositoryInstance)
        {
            _interfaceLessonRepositoryInstance = interfaceLessonRepositoryInstance;
        }

        public void Delete(int id)
        {
           _interfaceLessonRepositoryInstance.Delete(id);
        }

        public List<Lesson> Get()
        {
            return _interfaceLessonRepositoryInstance.Get();
        }

        public Lesson Get(int id)
        {
           return _interfaceLessonRepositoryInstance.Get(id);
        }

        public List<Lesson> GetLessonsByParticipant(int id)
        {
           return _interfaceLessonRepositoryInstance.GetLessonsByParticipant(id);
        }

        public List<Lesson> GetLessonsByTeacher(int id)
        {
           return _interfaceLessonRepositoryInstance.GetLessonsByTeacher(id);
        }

        public void Post(Lesson newLesson)
        {
            _interfaceLessonRepositoryInstance.Post(newLesson);
        }

        public void Put(int id, Lesson newLesson)
        {
            _interfaceLessonRepositoryInstance.Put(id, newLesson);
        }

        public void PutParticipantIntoLessons(int id, List<int> lessList)
        {
            _interfaceLessonRepositoryInstance.PutParticipantIntoLessons(id, lessList);
        }
    }
}
