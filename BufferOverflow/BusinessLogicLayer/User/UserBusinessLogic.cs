using DataAccessLayer.Repository;
using SharedLayer.DTOs;
using SharedLayer.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.User
{
    public class UserBusinessLogic
    {
        UserRepository userRepository;
        UserAuthentication userAuthenticate;

        public UserBusinessLogic()
        {
            userRepository = new UserRepository();
            userAuthenticate = new UserAuthentication();
        }

        //Method To Register New User
        public void RegisterNewUser(SignUpDTO signUpDTO)
        {
            userRepository.RegisterNewUser(signUpDTO);
        }

        //Method To Check if Email exists
        public bool CheckUser(string emailId)
        {
            return userRepository.CheckUser(emailId);
        }

        //SignIn Method
        public int SignInUser(SignInDTO signInDTO)
        {
            return userRepository.SignInUser(signInDTO);
        }

        //SignOut Method
        public void SignOut()
        {
            userAuthenticate.Logout();
        }

        //Method To get a user                
        public SignUpDTO GetUser(string FirstName)
        {
            return userRepository.GetUser(FirstName);
        }
    }
}
