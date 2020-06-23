using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BufferOverflow.ViewModels
{
    public class QuestionModel
    {
        [Key]
        public int QuestionId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please fill in the title of the question")]
        //[MaxLength(500, ErrorMessage = "Maximum 500 characters")]
        public string Title { get; set; }

        [Display(Name = "Tag")]
        [Required]
        public string TagList { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage ="Please describe your question!")]
        [DataType(DataType.MultilineText)]
        //[MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Description { get; set; }

        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        // Foreign Key
        [Required]
        public int UserId { get; set; }

        // A Question will have a list of answers 
        //public virtual ICollection<Answer> Answers { get; set; }
    }
}