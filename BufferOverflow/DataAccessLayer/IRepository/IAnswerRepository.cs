using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IAnswerRepository
    {
        AnswerDTO GetAnswer(int answerId);

        List<AnswerDTO> GetAnswerList(int questionId);

        void PostAnswer(AnswerDTO answerToPostDTO);

        void DeleteAnswer(int answerId);

        void LikeDislikeAnswer(LikeDislikeDTO answerVoteDTO);
    }
}
