using System.ComponentModel.DataAnnotations;

namespace IntroductionToEF.Model
{
    public class StudentCard
    {
        [Key]
        public int StudentID { get; set; }
        public string Period { get; set; }
        public string ClassIRN { get; set; }
        public Student Student { get; set; }
    }
}
