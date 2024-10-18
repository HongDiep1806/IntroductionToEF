namespace IntroductionToEF.Model
{
    public class Student
    {
        public int ID { get; set; }//
        public string LastName { get; set; }//
        public string FirstMidName { get; set; }//
        public List<Enrollment> Enrollments { get; set; } // list object : namecourse and id course 
        public StudentCard StudentCard { get; set; }

    }
}
