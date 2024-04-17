using BusinessLogicLayer;

public class ResponseWithAnswersDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public List<AnswerDTO>? Answers { get; set; }
}
