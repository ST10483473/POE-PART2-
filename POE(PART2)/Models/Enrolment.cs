namespace POE_PART2_.Models
{
    public class Enrolment
    {
        public int EnrolmentID { get; set; }

        public int ParticipantID { get; set; }

        public int CategoryID { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string? EnrolmentCode { get; set; }

        public User? Participant { get; set; }

        public Category? Category { get; set; }
    }
}