using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Domains
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }

        public string Title { get; set; }

        public string TagList { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        // Foreign Key
        public int UserId { get; set; }

        public virtual User User { get; set; }

        // A Question will have a list of answers 
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
