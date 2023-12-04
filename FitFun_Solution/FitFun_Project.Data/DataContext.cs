<<<<<<< HEAD:FitFun_Solution/FitFun_Project.Data/DataContext.cs
﻿using FitFun_Project.Entities;//added
=======
﻿using FitFun_Project.Controllers;
using FitFun_Project.Entities;
>>>>>>> 923bad43edbc44a91c99a6b4659e22a0c6a4cc98:FitFun_Solution/FitFun_Project/DataContext.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FitFun_Project
{
    public class DataContext
    {
      
        public List<Teacher> teachersList { get; set; }
        public int indexTeacher { get; set; }
        public List<Lesson> lessonsList { get; set; }
        public int indexLesson { get; set; }
        public List<Participant> participantsList { get; set; }
        public int indexParticipant { get; set; }
        public DataContext()
        {
            teachersList = new List<Teacher>{
            new Teacher { id = 0, age = 25, name = "Malci Katz", phoneNumber = "0556725888", experience = 3  },
                        new Teacher { id = 1, age = 21, name = "Hodaya Avivi", phoneNumber = "0556723568", experience = 1  }

        };
            indexTeacher = 2;
            lessonsList = new List<Lesson> {
           new Lesson
           {
               id =0, type = "power dance", price = 35, startHour = new DateTime(), endHour = new DateTime(), teacherId = 0, participantsIdList = new List<int>{0,1,2}
           },
           new Lesson
           {
               id =1, type = "pilates", price = 39, startHour = new DateTime(), endHour = new DateTime(), teacherId = 1, participantsIdList = new List<int>{1,2,3}
           }

       }; 
            indexLesson= 2;
            participantsList = new List<Participant> {
            
            new Participant { id = 0, name = "Orli Levi", phoneNumber = "0556712345" } ,
             new Participant { id = 1, name = "Tamar Yosef", phoneNumber = "0556718345" },
              new Participant { id = 2, name = "Michal Tzuker", phoneNumber = "0556112345" },
               new Participant { id = 3, name = "Shira Shoham", phoneNumber = "0556712343" }
        
    };
            indexParticipant= 4;

        }
 

    }
}
