using IntroductionToEF.Model;

namespace IntroductionToEF.WebModel
{
    public class CreateAssignmentResultRequest
    {
        public int ID { get; set; }
        public int AssignmentID { get; set; }
        public int Score { get; set; }
        public int StudentID { get; set; }

    }
}
