using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class GetAllCourseResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<EnrollmentResponse> Enrollments { get; set; }
        public List<AssignmentResponse> Assignments { get; set; }
    }
}
