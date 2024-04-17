
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class Response
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        //public ICollection<ResponseAnswer>? Answers { get; set; }
    }
}
