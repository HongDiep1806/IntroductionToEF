using System.ComponentModel.DataAnnotations;

namespace IntroductionToEF.WebModel
{
    public class CreateStudentRequest
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }
    }
}
