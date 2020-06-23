using BufferOverflow.Helper;
using BufferOverflow.ViewModels;
using BusinessLogicLayer.User;
using SharedLayer.DTOs;
using SharedLayer.Sessions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BufferOverflow.Controllers
{
    public class AccountController : ApiController
    {
        private UserBusinessLogic userBusinessLogic;

        public AccountController()
        {
            userBusinessLogic = new UserBusinessLogic();
        }



        // POST : api/Account/
        [Route("api/account")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]SignUpModel signUpModel)
        {
            SignUpDTO signUpDTO = ModelToDTOConversions.ModelToDTO(signUpModel);

            //Email already exists 
            bool isExist = IsEmailExist(signUpDTO.Email);   

            if (isExist)
            {
                return Ok(-1);
            }
            else
            {
                userBusinessLogic.RegisterNewUser(signUpDTO);
                return Ok(1);
            }
        }

        //Check If Email Already Exists.
        private bool IsEmailExist(string emailID)
        {
            bool Result = userBusinessLogic.CheckUser(emailID);
            return Result;
        }

        //Sign In Function
        [Route("api/account/SignIn")]
        public int SignIn(SignInModel signInModel)
        {
            SignInDTO signInDTO = ModelToDTOConversions.ModelToDTO(signInModel);
            int AuthenticatedId = userBusinessLogic.SignInUser(signInDTO);

            UserAuthentication userAuthenticateObject = new UserAuthentication();
            userAuthenticateObject.UserAuthenticate(AuthenticatedId);
            return AuthenticatedId;
        }

        //Sign Out Function
        public void SignOut()
        {
            userBusinessLogic.SignOut();
        }
    }
}
