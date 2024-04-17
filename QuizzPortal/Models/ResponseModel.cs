using DataAccessLayer;

namespace QuizzPortal.Models
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
       // public ResponseAnswer? Answers { get; set; }
    }
}
