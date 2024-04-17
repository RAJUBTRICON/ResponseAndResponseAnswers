namespace QuizzPortal.Models
{
    public class ResponseAnswerModel
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public string? AnswerText { get; set; }
    }
}
