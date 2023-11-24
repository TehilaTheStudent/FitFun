using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Core.Services
{
    public interface InterfaceLessonService
    {
        List<Lesson> Get();
        Lesson Get(int id);
        void PutParticipantIntoLessons(int id, List<int> lessList);
        List<Lesson> GetLessonsByTeacher(int id);
        List<Lesson> GetLessonsByParticipant(int id);
        void Post(Lesson newLesson);
        void Put(int id, Lesson newLesson);
        void Delete(int id);
    }
}
