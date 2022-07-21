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

    public class PreferenceTutorController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/PreferenceTutor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PreferenceTutor/5
        public string Get(int id)
        {
            return "value";
        }
        //קבלת עדיפות חונך
        [HttpGet]
        [Route("api/preferenceTutor/GetTutorPreference/{tutorId}/{preferenceId}")]
        public RequestResult GetTutorPreference(int tutorId,int preferenceId)
        {
            return db.GetPreferenceTutorById(preferenceId, tutorId);
        }
        //כל העדפות חונכים
        [HttpGet]
        [Route("api/PreferenceTutor/GetAllTutorsPreference")]
        public RequestResult GetAllTutorsPreference()
        {
            return db.GetAllPreferenceTutor();
        }
        //קבלת כל עדיפוית חונך
        [HttpGet]
        [Route("api/PreferenceTutor/GetTutorPreferences/{tutorId}")]
        public RequestResult GetTutorPreferences(int tutorId)
        {
            return db.GetAllTutorPreferences(tutorId);
        }
        // POST: api/PreferenceTutor
        public void Post([FromBody]string value)
        {
            //אין צורך בזה כי רק עדכון יש- ההוספה בוצעה כבר בהוספת החונך  
        }
        //עדכון העדפת חונך - שקופית 11
        //PUT : api/PreferenceTutor/5/5/5
        [HttpPut]
        [Route("api/PreferenceTutor/Put")]
        public void Put(PreferenceTutorDto preferenceTutor)
        {
            db.UpdateTutorPreference(preferenceTutor);
        }

        // DELETE: api/PreferenceTutor/5
        public void Delete(int id)
        {
        }
    }
}
