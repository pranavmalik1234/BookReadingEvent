using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IUserRepository
    {
        bool CheckUser(string emailId);

        void RegisterNewUser(SignUpDTO signUpDTO);

        SignUpDTO GetUser(string FirstName);

        int SignInUser(SignInDTO signInDTO);


    }
}
