using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Domains;
using SharedLayer.DTOs;

namespace BusinessLogicLayer.Answer
{
    public class AnswerBusinessLogic
    {
        AnswerRepository answerRepository;

        public AnswerBusinessLogic ()
        {
            answerRepository = new AnswerRepository();
        }

        /// <summary>
        /// Get a list of answers
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public List<AnswerDTO> GetAnswerList(int questionId)
        {
            return answerRepository.GetAnswerList(questionId);
        }

        /// <summary>
        /// Get Answer
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        public AnswerDTO GetAnswer(int answerId)
        {
            return answerRepository.GetAnswer(answerId);
        }

        /// <summary>
        /// Post Answer
        /// </summary>
        /// <param name="answerToPostDTO"></param>
        public void PostAnswer(AnswerDTO answerToPostDTO)
        {
            answerRepository.PostAnswer(answerToPostDTO);
        }

        /// <summary>
        /// Edit Answer
        /// </summary>
        /// <param name="answerId"></param>
        public void EditAnswer(AnswerDTO answerDTOToEdit)
        {
            answerRepository.EditAnswer(answerDTOToEdit);
        }

        /// <summary>
        /// Delete answer
        /// </summary>
        /// <param name="answerId"></param>
        public void DeleteAnswer(int answerId)
        {
            answerRepository.DeleteAnswer(answerId);
        }

        /// <summary>
        /// Vote Answer
        /// </summary>
        /// <param name="answerDTO"></param>
        public void VoteAnswer(LikeDislikeDTO likeDislikeDTO)
        {
            answerRepository.VoteAnswer(likeDislikeDTO);

        }
    }
}
