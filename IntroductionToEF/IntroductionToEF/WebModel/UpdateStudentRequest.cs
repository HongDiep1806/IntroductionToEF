using System.ComponentModel.DataAnnotations;

namespace IntroductionToEF.WebModel
{
    public class UpdateStudentRequest
    {
        [Required]
        public int Id { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
    }
}
