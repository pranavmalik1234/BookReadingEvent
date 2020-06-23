using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.DTOs
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }

        public string Title { get; set; }

        public string TagList { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        // Foreign Key
        public int UserId { get; set; }
    }
}
