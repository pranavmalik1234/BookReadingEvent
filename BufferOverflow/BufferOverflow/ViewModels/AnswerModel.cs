using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BufferOverflow.ViewModels
{
    public class AnswerModel
    {
        [Key]
        public int AnswerId { get; set; }

        public string AnswerDetail { get; set; }

        public int Vote { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        //Foreign Key
        public int QuestionId { get; set; }

        //public virtual Question Question { get; set; }

        //Foreign Key
        public int UserId { get; set; }

        //public virtual User User { get; set; }
    }
}