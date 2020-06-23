using AutoMapper;
using DataAccessLayer.Domains;
using SharedLayer.DTOs;
using System.Collections.Generic;

namespace DataAccessLayer.Helper
{
    public class EntityToDTOConversions
    {
        // Method 1 : SignUpDTO To User Entity
        private static MapperConfiguration config1 = new MapperConfiguration(c =>
        {
            c.CreateMap<SignUpDTO, User>();
        });
        private static IMapper mapper1 = config1.CreateMapper();

        public static User DTOToModel(SignUpDTO signUpDTO)
        {
            return mapper1.Map<User>(signUpDTO);
        }

        //Method 2 : User Model To SignUp DTO
        private static MapperConfiguration config2 = new MapperConfiguration(c =>
        {
            c.CreateMap<User, SignUpDTO>();
        });
        private static IMapper mapper2 = config2.CreateMapper();

        public static SignUpDTO ModelToDTO(User userToConvert)
        {
            return mapper2.Map<SignUpDTO>(userToConvert);
        }

        //Method 3 : Question To Question DTO 
        private static MapperConfiguration config3 = new MapperConfiguration(c =>
        {
            c.CreateMap<Question, QuestionDTO>();
        });
        private static IMapper mapper3 = config3.CreateMapper();

        public static QuestionDTO ModelToDTO(Question questionToConvert)
        {
            return mapper3.Map<QuestionDTO>(questionToConvert);
        }

        //Method 4 : QuestionDTO To Question
        private static MapperConfiguration config4 = new MapperConfiguration(c =>
        {
            c.CreateMap<QuestionDTO, Question>();
        });
        private static IMapper mapper4 = config4.CreateMapper();

        public static Question DTOToModel(QuestionDTO questionDTOToConvert)
        {
            return mapper4.Map<Question>(questionDTOToConvert);
        }

        //Method 5 : AnswerList To AnswerDTOList
        private static MapperConfiguration config5 = new MapperConfiguration(c =>
        {
            c.CreateMap<Answer, AnswerDTO>();
        });
        private static IMapper mapper5 = config5.CreateMapper();

        public static List<AnswerDTO> ModelToDTO(List<Answer> answerList)
        {
            return mapper5.Map<List<AnswerDTO>>(answerList);
        }

        //Method 6 : QuestionList To QuestionDTO List
        private static MapperConfiguration config6 = new MapperConfiguration(c =>
        {
            c.CreateMap<Question,QuestionDTO>();
        });
        private static IMapper mapper6 = config6.CreateMapper();

        public static List<QuestionDTO> ModelToDTO(List<Question> answerList)
        {
            return mapper6.Map<List<QuestionDTO>>(answerList);
        }

        //Method 7 : Answer To AnswerDTO
        private static MapperConfiguration config7 = new MapperConfiguration(c =>
        {
            c.CreateMap<Answer, AnswerDTO>();
        });
        private static IMapper mapper7 = config7.CreateMapper();

        public static AnswerDTO ModelToDTO(Answer answerToConvert)
        {
            return mapper7.Map<AnswerDTO>(answerToConvert);
        }

        //Method 8 : AnswerDTO To Answer
        private static MapperConfiguration config8 = new MapperConfiguration(c =>
        {
            c.CreateMap<AnswerDTO, Answer>();
        });
        private static IMapper mapper8 = config8.CreateMapper();

        public static Answer DTOToModel(AnswerDTO answerDTOToConvert)
        {
            return mapper8.Map<Answer>(answerDTOToConvert);
        }
    }
}
