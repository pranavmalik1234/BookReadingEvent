using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Domains
{
    public class LikeDislike
    {
        public int LikeDislikeId { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public int Vote { get; set; }


    }
}
