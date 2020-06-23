    using BusinessLogicLayer.User;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BufferOverflow.Controllers
{
    public class UserController : ApiController
    {
        UserBusinessLogic userBusinessLogic;

        public UserController()
        {
            userBusinessLogic = new UserBusinessLogic();
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [Route("api/user/{firstname}")]
        public SignUpDTO Get(string FirstName)
        {
            return userBusinessLogic.GetUser(FirstName);
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
