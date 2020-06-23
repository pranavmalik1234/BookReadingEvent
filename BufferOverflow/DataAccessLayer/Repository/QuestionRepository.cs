using DataAccessLayer.Database;
using DataAccessLayer.Domains;
using DataAccessLayer.Helper;
using DataAccessLayer.IRepository;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class QuestionRepository : IQuestionRepository,IDisposable
    {
        private BufferOverflowContext context;

        public QuestionRepository()
        {
            context = new BufferOverflowContext();
        }

        /// <summary>
        /// Method to get a single question to show details
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public QuestionDTO GetOneQuestion(int questionId)
        {
            Question questionToShow = context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefault();
            QuestionDTO questionToShowDTO = EntityToDTOConversions.ModelToDTO(questionToShow);

            return questionToShowDTO;
        }

        /// <summary>
        /// Method to get all questions
        /// </summary>
        /// <returns></returns> 
        public List<QuestionDTO> GetAllQuestions(string sortOrder)
        {
            if (sortOrder.Equals("null"))
            {
                List<Question> AllQuestionsList = context.Questions.OrderByDescending(d => d.QuestionId).ToList();
                List<QuestionDTO> QuestionDTOList = EntityToDTOConversions.ModelToDTO(AllQuestionsList);
                return QuestionDTOList;
            }
            else
            {
                List<Question> AllQuestionsList = context.Questions.OrderBy(d => d.Title).ToList();
                List<QuestionDTO> QuestionDTOList = EntityToDTOConversions.ModelToDTO(AllQuestionsList);
                return QuestionDTOList;
            }
            
        }

        /// <summary>
        /// Add a new Question To Database
        /// </summary>
        /// <param name="questionDTO"></param>
        public void AddQuestion(QuestionDTO questionDTO)
        {
            Question questionToAdd = EntityToDTOConversions.DTOToModel(questionDTO);
            context.Questions.Add(questionToAdd);
            context.SaveChanges();
        }

        /// <summary>
        /// Edit Question
        /// </summary>
        /// <param name="questionDTOToEdit"></param>
        public void EditQuestion(QuestionDTO questionDTOToEdit)
        {
            Question UpdatedQuestion = EntityToDTOConversions.DTOToModel(questionDTOToEdit);
            var Data = context.Questions.Where(q => q.QuestionId == questionDTOToEdit.QuestionId).FirstOrDefault<Question>();
            if (Data != null)
            {
                Data.Description = UpdatedQuestion.Description;
                Data.ImageUrl = UpdatedQuestion.ImageUrl;
                Data.TagList = UpdatedQuestion.TagList;
                Data.Title = UpdatedQuestion.Title;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Delete Question
        /// </summary>
        /// <param name="questionId"></param>
        
        public void DeleteQuestion(int questionId)
        {
            Question questionToDelete = context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefault();
            List<Answer> AnswerListToDelete = context.Answers.Where(a => a.QuestionId == questionId).ToList();
            context.Answers.RemoveRange(AnswerListToDelete);
            context.Questions.Remove(questionToDelete);
            context.SaveChanges();
        }

        public List<QuestionDTO> SearchQuestion(string searchQuestion)
        {
            List<Question> searchedQuestionList = context.Questions.Where(q => q.Description.Contains(searchQuestion) || q.TagList.Contains(searchQuestion)).ToList();
            List<QuestionDTO> SearchedquestionDTOList = EntityToDTOConversions.ModelToDTO(searchedQuestionList);
            return SearchedquestionDTOList; 
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
