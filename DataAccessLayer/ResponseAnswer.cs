using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ResponseAnswer
    {
        public int Id {  get; set; }    
        public int ResponseId { get; set; } 
        public int QuestionId { get; set; }
        public string? AnswerText { get; set; }
    }
}
