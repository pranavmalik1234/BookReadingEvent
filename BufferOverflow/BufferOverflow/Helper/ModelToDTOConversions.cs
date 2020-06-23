using AutoMapper;
using BufferOverflow.ViewModels;
using SharedLayer.DTOs;
using System.Collections.Generic;

namespace BufferOverflow.Helper
{
    public class ModelToDTOConversions
    {
        // Method 1 : SignUoModel to SignUpDTO
        private static MapperConfiguration config1 = new MapperConfiguration(c =>
        {
            c.CreateMap<SignUpModel, SignUpDTO>();
        });
        private static IMapper mapper1 = config1.CreateMapper();

        public static SignUpDTO ModelToDTO(SignUpModel signUpUser)
        {
            return mapper1.Map<SignUpDTO>(signUpUser);
        }

        //Method 2 : QuestionDTO To QuestionModel
        private static MapperConfiguration config2 = new MapperConfiguration(c =>
        {
            c.CreateMap<QuestionDTO, QuestionModel>();
        });
        private static IMapper mapper2 = config2.CreateMapper();

        public static QuestionModel DTOToModel(QuestionDTO questionDTOToConvert)
        {
            return mapper2.Map<QuestionModel>(questionDTOToConvert);
        }

        //Method 3 : Question Model To Question DTO
        private static MapperConfiguration config3 = new MapperConfiguration(c =>
        {
            c.CreateMap<QuestionModel, QuestionDTO>();
        });
        private static IMapper mapper3 = config3.CreateMapper();

        public static QuestionDTO ModelToDTO(QuestionModel questionModelToConvert)
        {
            return mapper3.Map<QuestionDTO>(questionModelToConvert);
        }

        // Method 4 : AnswerDTOList To AnswerModelList
        private static MapperConfiguration config4 = new MapperConfiguration(c =>
        {
            c.CreateMap<AnswerDTO, AnswerModel>();
        });
        private static IMapper mapper4 = config4.CreateMapper();

        public static List<AnswerModel> DTOToModel(List<AnswerDTO> answerDTOList)
        {
            return mapper4.Map<List<AnswerModel>>(answerDTOList);
        }

        //Method 5 : SignInModel To SignInDTO
        private static MapperConfiguration config5 = new MapperConfiguration(c =>
        {
            c.CreateMap<SignInModel, SignInDTO>();
        });
        private static IMapper mapper5 = config5.CreateMapper();

        public static SignInDTO ModelToDTO(SignInModel signInModelToConvert)
        {
            return mapper3.Map<SignInDTO>(signInModelToConvert);
        }

        //Method 6 : QuestionDTOList To QuestionModelList
        private static MapperConfiguration config6 = new MapperConfiguration(c =>
        {
            c.CreateMap<QuestionDTO,QuestionModel>();
        });
        private static IMapper mapper6 = config6.CreateMapper();

        public static List<QuestionModel> DTOToModel(List<QuestionDTO> answerDTOList)
        {
            return mapper6.Map<List<QuestionModel>>(answerDTOList);
        }

        // Method 7 : AnswerModel To AnswerDTO
        private static MapperConfiguration config7 = new MapperConfiguration(c =>
        {
            c.CreateMap<AnswerModel, AnswerDTO>();
        });
        private static IMapper mapper7 = config7.CreateMapper();

        public static AnswerDTO ModelToDTO(AnswerModel answerModelToConvert)
        {
            return mapper7.Map<AnswerDTO>(answerModelToConvert);
        }

        //Method 8 : AnswerDTO To AnswerModel
        private static MapperConfiguration config8 = new MapperConfiguration(c =>
        {
            c.CreateMap<AnswerDTO, AnswerModel>();
        });
        private static IMapper mapper8 = config8.CreateMapper();

        public static AnswerModel DTOToModel(AnswerDTO questionDTOToConvert)
        {
            return mapper8.Map<AnswerModel>(questionDTOToConvert);
        }
    }
}
