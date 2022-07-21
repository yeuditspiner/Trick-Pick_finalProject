using Bll;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSmartMatch.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PreferenceController : ApiController
    {
        DbClass db = new DbClass();
        // POST: api/Preference
        public void Post(PreferenceDto prefrence)
        {
            db.AddPreference(prefrence);
        }

        [HttpGet]
        [Route("api/preference/Get")]
        public RequestResult Get()
        {
            return db.GettAllPreference();

        }
        // GET: api/Preference/5
        public string Get(int id)
        {
            return "value";
        }
     

        // PUT: api/Preference/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Preference/5
        public void Delete(int id)
        {
        }
        //[HttpGet]
        //[Route("api/Preference/Preferences")]
        //public RequestResult Preferences()
        //{
        //    return db.GettAllPreference();
        //}
        
    }
}
