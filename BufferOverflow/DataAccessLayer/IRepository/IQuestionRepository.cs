using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IQuestionRepository
    {
        QuestionDTO GetOneQuestion(int questionId);

        List<QuestionDTO> GetAllQuestions(string sortOrder);

        void AddQuestion(QuestionDTO questionDTO);

        void EditQuestion(QuestionDTO questionDTOToEdit);

        void DeleteQuestion(int questionId);
    }
}
