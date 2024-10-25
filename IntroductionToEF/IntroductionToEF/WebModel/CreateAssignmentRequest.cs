using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class CreateAssignmentRequest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseID { get; set; }
    }
}
