using DataAccessLayer.Database;
using DataAccessLayer.Domains;
using DataAccessLayer.Helper;
using DataAccessLayer.IRepository;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        BufferOverflowContext context;

        public UserRepository()
        {
            context = new BufferOverflowContext();
        }

        /// <summary>
        /// Check if Email Exists or Not
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public bool CheckUser(string emailId)
        {
            User userFoundOrNot = context.Users.FirstOrDefault(u => u.Email == emailId);

            if (userFoundOrNot == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="signUpDTO"></param>
        public void RegisterNewUser(SignUpDTO signUpDTO)
        {
            User userToRegister = EntityToDTOConversions.DTOToModel(signUpDTO);
            context.Users.Add(userToRegister);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to get user by firstname
        /// </summary>
        /// <param name="FirstName"></param>
        /// <returns></returns>
        public SignUpDTO GetUser(string FirstName)
        {
            User userToGet = context.Users.Where(u => u.FirstName == FirstName).FirstOrDefault();
            SignUpDTO userToGetDTO = EntityToDTOConversions.ModelToDTO(userToGet);
            return userToGetDTO;
        }

        /// <summary>
        /// Method SignIn User
        /// </summary>
        /// <param name="signInDTO"></param>
        /// <returns></returns>
        public int SignInUser(SignInDTO signInDTO)
        {
            try
            {
                var UserToLog = context.Users.Select(u => new { u.UserId, u.Email, u.Password });
                UserToLog = (UserToLog.Where(m => m.Email.Contains(signInDTO.Email)));

                if (UserToLog != null)
                {
                    var UserPassword = UserToLog.Select(u => u.Password).Single().ToString();
                    if (UserPassword == signInDTO.Password)
                    {
                        return UserToLog.Select(s => s.UserId).Single();
                    }
                }
                else
                {
                    return -1;
                }
                return -1;
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return -1;
            }  
        }
    }
}
