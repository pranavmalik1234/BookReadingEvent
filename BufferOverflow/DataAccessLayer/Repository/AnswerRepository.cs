using DataAccessLayer.Database;
using DataAccessLayer.Domains;
using DataAccessLayer.Helper;
using DataAccessLayer.IRepository;
using SharedLayer.DTOs;
using SharedLayer.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AnswerRepository 
    {
        private BufferOverflowContext context;

        public AnswerRepository()
        {
            context = new BufferOverflowContext();
        }

        /// <summary>
        /// Get answer based on Id
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        public AnswerDTO GetAnswer(int answerId)
        {
            Answer AnswerToGet = context.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            AnswerDTO AnswerToGetDTO = EntityToDTOConversions.ModelToDTO(AnswerToGet);
            return AnswerToGetDTO;
        }

        /// <summary>
        /// Get a list of answers
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public List<AnswerDTO> GetAnswerList(int questionId)
        {
            List<Answer> AnswerList = context.Answers.Where(a => a.QuestionId == questionId).OrderByDescending(d => d.UpVotes - d.DownVotes).ToList();
            List<AnswerDTO> AnswerDTOList = EntityToDTOConversions.ModelToDTO(AnswerList);

            return AnswerDTOList;
        }

        /// <summary>
        /// Post Answer
        /// </summary>
        /// <param name="answerToPostDTO"></param>
        public void PostAnswer(AnswerDTO answerToPostDTO)
        {
            Answer answerToPost = EntityToDTOConversions.DTOToModel(answerToPostDTO);
            context.Answers.Add(answerToPost);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to edit an answer
        /// </summary>
        /// <param name="answerDTOToEdit"></param>
        public void EditAnswer(AnswerDTO answerDTOToEdit)
        {
            Answer UpdatedAnswer = EntityToDTOConversions.DTOToModel(answerDTOToEdit);
            var Data = context.Answers.Where(a => a.AnswerId == answerDTOToEdit.AnswerId).FirstOrDefault<Answer>();
            if (Data != null)
            {
                Data.AnswerDetail = UpdatedAnswer.AnswerDetail;
                Data.DownVotes = UpdatedAnswer.DownVotes;
                Data.UpVotes = UpdatedAnswer.UpVotes;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Delete answer
        /// </summary>
        /// <param name="answerId"></param>
        /// 

        public void DeleteAnswer(int answerId)
        {
            Answer AnswerToDelete = context.Answers.Where(a => a.AnswerId == answerId).FirstOrDefault();
            context.Answers.Remove(AnswerToDelete);
            context.SaveChanges();
        }


        /// <summary>
        /// Vote Answer
        /// </summary>
        /// <param name="answerVoteDTO"></param>
        public void VoteAnswer(LikeDislikeDTO answerVoteDTO)
        {
            LikeDislike answerVote = new LikeDislike();
            Answer answer = new Answer();

            if ((context.LikeDislikes.Where(x => x.UserId == answerVoteDTO.UserId && x.AnswerId == answerVoteDTO.AnswerId).FirstOrDefault()) == null)
            {
                answerVote.AnswerId = answerVoteDTO.AnswerId;
                answerVote.Vote = answerVoteDTO.Vote;
                answerVote.UserId = answerVoteDTO.UserId;

                answer = context.Answers.Where(x => x.AnswerId == answerVoteDTO.AnswerId).FirstOrDefault();
                if (answerVote.Vote == 1)
                {
                    answer.UpVotes++;
                }
                else
                {
                    answer.DownVotes++;
                }

                context.LikeDislikes.Add(answerVote);
                context.SaveChanges();
            }

            else
            {
                answerVote = context.LikeDislikes.Where(x => x.UserId == answerVoteDTO.UserId && x.AnswerId == answerVoteDTO.AnswerId).FirstOrDefault();

                if (answerVoteDTO.Vote == answerVote.Vote)
                {

                    return;
                }

                else
                {
                    if (answerVoteDTO.Vote == 2 && answerVote.Vote == 1)
                    {
                        answerVote.Vote = 2;
                        answer = context.Answers.Where(x => x.AnswerId == answerVoteDTO.AnswerId).FirstOrDefault();
                        answer.DownVotes++;
                        answer.UpVotes--;
                    }

                    else if (answerVoteDTO.Vote == 1 && answerVote.Vote == 2)
                    {
                        answerVote.Vote = 1;
                        answer = context.Answers.Where(x => x.AnswerId == answerVoteDTO.AnswerId).FirstOrDefault();
                        answer.DownVotes--;
                        answer.UpVotes++;
                    }
                }
            }
            context.SaveChanges();
        }

    }
}

