using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.DTOs
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }

        public string AnswerDetail { get; set; }

        public int Vote { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        //Foreign Key
        public int QuestionId { get; set; }

        //Foreign Key
        public int UserId { get; set; }
    }
}
