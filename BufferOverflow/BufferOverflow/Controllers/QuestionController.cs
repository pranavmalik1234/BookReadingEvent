using BufferOverflow.Helper;
using BufferOverflow.ViewModels;
using BusinessLogicLayer.Question;
using SharedLayer.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace BufferOverflow.Controllers
{
    public class QuestionController : ApiController
    {
        private QuestionBusinessLogic questionBusinessLogic;

        //Injecting Business Logic
        public QuestionController()
        {
            questionBusinessLogic = new QuestionBusinessLogic();
        }

        /// <summary>
        /// Get question details
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [Route("api/question/{questionId}")]
        [HttpGet]
        public IHttpActionResult Get(int questionId)
        {
            var QuestionData =  questionBusinessLogic.GetOneQuestion(questionId);
            if(QuestionData == null)
            {
                return NotFound();
            }
            return Ok(QuestionData);
        }

        /// <summary>
        /// Get All Questions
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/question/GetAllQuestions/{sortOrder}")]
        [HttpGet]
        public List<QuestionModel> GetAllQuestions(string sortOrder)
        {
            List<QuestionDTO> QuestionDTOList = questionBusinessLogic.GetAllQuestions(sortOrder);
            List<QuestionModel> QuestionModelList = ModelToDTOConversions.DTOToModel(QuestionDTOList);
            return QuestionModelList;
        }

        /// <summary>
        /// Method to post a new question
        /// </summary>
        /// <param name="questionModel"></param>
        /// <returns></returns>
        [Route("api/question")]
        [HttpPost]
        public IHttpActionResult PostQuestion([FromBody] QuestionModel questionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                QuestionDTO QuestionDTO = ModelToDTOConversions.ModelToDTO(questionModel);
                questionBusinessLogic.AddQuestion(QuestionDTO);
                return Ok();
            }
        }

        /// <summary>
        /// Method to edit a question
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="questionToEditModel"></param>
        /// <returns></returns>
        [Route("api/question/EditQuestion/{questionId}")]
        [HttpPut]
        public IHttpActionResult PutEditQuestion(int questionId, [FromBody]QuestionModel questionToEditModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}

            if (questionToEditModel.QuestionId != questionId)
            {
                return BadRequest();
            }

            QuestionDTO questionToEditDTO = ModelToDTOConversions.ModelToDTO(questionToEditModel);
            questionBusinessLogic.EditQuestion(questionToEditDTO);
            return Ok();
        }

        /// <summary>
        /// Method to delete a question
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [Route("api/question/{questionId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int questionId)
        {
            questionBusinessLogic.DeleteQuestion(questionId);
            return Ok();
        }

        [Route("api/question/SearchQuestion/{searchString}")]
        [HttpGet]
        public List<QuestionDTO> SearchQuestion(string searchString)
        {
            return questionBusinessLogic.SearchQuestion(searchString);
        }
    }
}
