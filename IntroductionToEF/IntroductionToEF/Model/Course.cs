using System.ComponentModel.DataAnnotations.Schema;

namespace IntroductionToEF.Model
{
    public class Course
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

    }
}
