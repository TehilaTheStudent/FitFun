﻿namespace FitFun_Project.Entities
{
    public class Lesson
    {
        public int ID { get; set; }
        public string? type { get; set; }
        public int price { get; set; }
        public DateTime startHour { get; set; }
        public DateTime endHour { get; set; }
        public int teacherId { get; set; }
       // public List<int>? list { get; set; }
    }
}
