using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSmartMatch.Controllers
{
    public class UserController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("api/user/GetUser/{username}/{password}")]
        public RequestResult GetUser(string  username,string password)
        {
            RequestResult requestResult= db.GetUserByUserNameAndPassword(username, password);
            if (requestResult.Data == null)
                requestResult.Data = "not found";
                return requestResult;      
        }
    }
}
