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
            foreach (var lessI in _dataContextInstance.lessonsList)
            {//participant not signed and  wants to sign
                if (!lessI.participantsIdList.Exists(partI => partI == id) && lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Add(id);
                //participant  signed and doesnt want to sign
                if (lessI.participantsIdList.Exists(partI => partI == id) && !lessList.Exists(lessId => lessId == lessI.id))
                    lessI.participantsIdList.Remove(id);
            }
        }

    
        public List<Lesson> GetLessonsByTeacher(int id)
        {
            return _dataContextInstance.lessonsList.FindAll(lessI => lessI.teacherId == id);
        }
  
        public List<Lesson> GetLessonsByParticipant(int id)
        {
            return _dataContextInstance.lessonsList.FindAll(lessI => lessI.participantsIdList.Exists(partI => partI == id));
        }


        public List<Lesson> Get()
        {
            return _dataContextInstance.lessonsList;
        }


        //public List<Lesson> GetHoursRange([FromQuery] int startH, [FromQuery] int endH)
        //{
        //    if (_lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH).Count != 0)
        //        return _lessons.FindAll(lessI => lessI.startHour.Hour >= startH && lessI.endHour.Hour <= endH);
        //    return null;
        //}
 
        public Lesson Get(int id)
        {
            return _dataContextInstance.lessonsList.Find(lessI => lessI.id == id);

        }


        public void Post( Lesson newLesson)
        {

            _dataContextInstance.lessonsList.Add(new Lesson
            {
                id = _dataContextInstance.indexLesson++,
                type = newLesson.type,
                price = newLesson.price,
                startHour = newLesson.startHour,
                endHour = newLesson.endHour,
                teacherId = newLesson.teacherId,
                participantsIdList = newLesson.participantsIdList

            });
        }


        public void Put(int id, Lesson newLesson)
        {
            var deleteLesson = _dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            _dataContextInstance.lessonsList.Remove(deleteLesson);
            _dataContextInstance.lessonsList.Add(new Lesson { id = id, type = newLesson.type, price = newLesson.price, startHour = newLesson.startHour, endHour = newLesson.endHour, teacherId = newLesson.teacherId, participantsIdList = newLesson.participantsIdList }
            );
        }

        public void Delete(int id)
        {
            var deleteLesson = _dataContextInstance.lessonsList.Find(lessI => lessI.id == id);
            _dataContextInstance.lessonsList.Remove(deleteLesson);
        }
    }
}
