using System.ComponentModel.DataAnnotations;

namespace IntroductionToEF.WebModel
{
    public class CreateEnrollmentRequest
    {

        [Required]
        public int StudentID { get; set; }
        [Required]
        public int CourseID { get; set; }
    }
}
