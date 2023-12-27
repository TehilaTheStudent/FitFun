using FitFun_Project.Core.Repositories;//added
using FitFun_Project.Entities;//added
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFun_Project.Data.Rpositories
{
    public class LessonRepository:InterfaceLessonRepository
    {
        private readonly DataContext _dataContextInstance;
        public LessonRepository(DataContext dataContextInstance)
        {
            this._dataContextInstance = dataContextInstance;
        }

      
        public void PutParticipantIntoLessons(int id,List<int> lessList)
        {
            //foreach (var lessI in _dataContextInstance.lessonsData.ToList<Lesson>())
            //{//participant not signed and  wants to sign
            //    if (!lessI.IDENTITY.Exists(partI => partI == id) && lessList.Exists(lessId => lessId == lessI.ID))
            //        lessI.IDENTITY.Add(id);
            //    //participant  signed and doesnt want to sign
            //    if (lessI.IDENTITY.Exists(partI => partI == id) && !lessList.Exists(lessId => lessId == lessI.ID))
            //        lessI.IDENTITY.Remove(id);
            //}
        }

    
        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _dataContextInstance.lessonsData.ToList<Lesson>().FindAll(lessI => lessI.teacherId == id);
        }
  
        public List<Lesson> GetLessonsByParticipant(int id)
        {
            //   return _dataContextInstance.lessonsData.ToList<Lesson>().FindAll(lessI => lessI.IDENTITY.Exists(partI => partI == id));
            return null;
        }


        public List<Lesson> Get()
        {
            return _dataContextInstance.lessonsData.ToList<Lesson>();
        }


        //public List<Lesson> GetHoursRange([FromQuery] int startH, [FromQuery] int endH)
        //{
        //    if (_lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH).Count != 0)
        //        return _lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH);
        //    return null;
        //}
 
        public Lesson Get(int id)
        {
            return _dataContextInstance.lessonsData.ToList<Lesson>().Find(lessI => lessI.ID == id);

        }


        public void Post( Lesson newLesson)
        {

            _dataContextInstance.lessonsData.ToList<Lesson>().Add(new Lesson
            {
                ID = _dataContextInstance.indexLesson++,
                type = newLesson.type,
                price = newLesson.price,
                startHour = newLesson.startHour,
                endHour = newLesson.endHour,
                teacherId = newLesson.teacherId,
              //  IDENTITY = newLesson.IDENTITY

            });
        }


        public void Put(int id, Lesson newLesson)
        {
            var deleteLesson = _dataContextInstance.lessonsData.ToList<Lesson>().Find(lessI => lessI.ID == id);
            _dataContextInstance.lessonsData.ToList<Lesson>().Remove(deleteLesson);
           // _dataContextInstance.lessonsData.ToList<Lesson>().Add(new Lesson { ID = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, IDENTITY = newLesson.IDENTITY }
            _dataContextInstance.lessonsData.ToList<Lesson>().Add(new Lesson { ID = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId}

            );
        }

        public void Delete(int id)
        {
            var deleteLesson = _dataContextInstance.lessonsData.ToList<Lesson>().Find(lessI => lessI.ID == id);
            _dataContextInstance.lessonsData.ToList<Lesson>().Remove(deleteLesson);
        }
    }
}
