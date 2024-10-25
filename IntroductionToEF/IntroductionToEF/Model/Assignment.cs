﻿namespace IntroductionToEF.Model
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }  
    }
}
