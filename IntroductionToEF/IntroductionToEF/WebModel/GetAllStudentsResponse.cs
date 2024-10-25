using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class GetAllStudentsResponse
    {
        public int StudentId { get; set; }
        public string StudentFirstMidName { get; set; }
        public string StudentLastName { get; set; }
        public List<RegisteredCourse> RegisteredCourseList { get; set; }
        public CardResponse CardResponse { get; set; }
        public List<AssignmentResultResponse> AssignmentResultResponse { get; set; }    
    }
}
