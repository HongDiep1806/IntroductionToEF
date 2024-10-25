namespace IntroductionToEF.Model
{
    public class AssignmentResult
    {
        public int ID { get; set; }
        public int AssignmentID { get; set; }
        public Assignment Assignment { get; set; }
        public int Score { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }


    }
}
