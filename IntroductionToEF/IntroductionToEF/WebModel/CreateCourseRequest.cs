using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class CreateCourseRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }
}
