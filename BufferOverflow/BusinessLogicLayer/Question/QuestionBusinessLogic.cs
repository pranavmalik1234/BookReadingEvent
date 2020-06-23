using DataAccessLayer.Repository;
using SharedLayer.DTOs;
using System.Collections.Generic;

namespace BusinessLogicLayer.Question
{
    public class QuestionBusinessLogic
    {

        QuestionRepository questionRepository;

        public QuestionBusinessLogic()
        {
            questionRepository = new QuestionRepository();
        }

        // Function to get a single question to show details
        public QuestionDTO GetOneQuestion(int questionId)
        {
            return questionRepository.GetOneQuestion(questionId);
        }

        //Function to get all questions 
        public List<QuestionDTO> GetAllQuestions(string sortOrder)
        {
            return questionRepository.GetAllQuestions(sortOrder);
        }

        //Adding a new question
        public void AddQuestion(QuestionDTO questionDTO)
        {
            questionRepository.AddQuestion(questionDTO);
        }

        //Deleting a question
        public void DeleteQuestion(int questionId)
        {
            questionRepository.DeleteQuestion(questionId);
        }

        //Edit a Question
        public void EditQuestion(QuestionDTO questionDTOToEdit)
        {
            questionRepository.EditQuestion(questionDTOToEdit);
        }

        public List<QuestionDTO> SearchQuestion(string searchQuestion)
        {
            return questionRepository.SearchQuestion(searchQuestion);
        }
    }
}
