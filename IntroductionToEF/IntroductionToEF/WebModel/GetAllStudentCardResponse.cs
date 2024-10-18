using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class GetAllStudentCardResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Period { get; set; }
        public string ClassIRN { get; set; }
    }
}
