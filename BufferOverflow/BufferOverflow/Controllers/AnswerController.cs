using BufferOverflow.Helper;
using BufferOverflow.ViewModels;
using BusinessLogicLayer.Answer;
using SharedLayer.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace BufferOverflow.Controllers
{
    public class AnswerController : ApiController
    {
        private AnswerBusinessLogic answerBusinessLogic;

      public AnswerController()
        {
            answerBusinessLogic = new AnswerBusinessLogic();
        }

        /// <summary>
        /// Get answer based on Id
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        [Route("api/answer/{answerId}")]
        [HttpGet]
        public AnswerModel Get(int answerId)
        {
            AnswerDTO AnswerToGetDTO = answerBusinessLogic.GetAnswer(answerId);
            AnswerModel Answer = ModelToDTOConversions.DTOToModel(AnswerToGetDTO);

            return Answer;
        }

        /// <summary>
        /// GET: api/Answer/5   : Get a list of answers for a question
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        /// 
        [Route("api/answer/GetAnswerList/{questionId}")]
        public List<AnswerModel> GetAnswerList(int questionId)
        {
            List<AnswerDTO> answerDTOList = answerBusinessLogic.GetAnswerList(questionId);
            List<AnswerModel> AnswerList = ModelToDTOConversions.DTOToModel(answerDTOList);

            return AnswerList;
        }

        /// <summary>
        /// POST: api/Answer , Answer a question
        /// </summary>
        /// <param name="answerToPost"></param>
        /// <returns></returns>
        /// 
        [Route("api/answer")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]AnswerModel answerToPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                AnswerDTO AnswerDTOToPost = ModelToDTOConversions.ModelToDTO(answerToPost);
                answerBusinessLogic.PostAnswer(AnswerDTOToPost);
                return Ok();
            }  
        }

        /// <summary>
        /// api/Answer/5 , Edit answer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [Route("api/answer/{answerId}")]
        [HttpPut]
        public IHttpActionResult PutEditAnswer(int answerId, AnswerModel answerToEditModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (answerToEditModel.AnswerId != answerId)
            {
                return BadRequest();
            }
            AnswerDTO answerToEditDTO = ModelToDTOConversions.ModelToDTO(answerToEditModel);
            answerBusinessLogic.EditAnswer(answerToEditDTO);
            return Ok(answerToEditModel);
        }

        // DELETE: api/Answer/5
        [Route("api/answer/{answerId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int answerId)
        {
            answerBusinessLogic.DeleteAnswer(answerId);
            return Ok();
        }

        [Route("api/answer/LikeDislikeAnswer")]
        [HttpPost]
        public IHttpActionResult LikeDislikeAnswer(LikeDislikeDTO likeDislikeDTO)
        {
            answerBusinessLogic.VoteAnswer(likeDislikeDTO);
            return Ok();
        }
    }
}
