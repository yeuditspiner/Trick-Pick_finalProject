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

    public class PreferenceApprenticeController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/PreferenceApprentice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PreferenceApprentice/5
        public string Get(int id)
        {
            return "value";
        }
        //קבלת עדיפות חניך
        [HttpGet]
        [Route("api/preferenceApprentice/GetApprenticePreference/{apprenticeId}/{preferenceId}")]
        public RequestResult GetApprenticePreference(int apprenticeId, int preferenceId)
        {
            return db.GetPreferenceApprenticeById(preferenceId,apprenticeId);
        }
        //כל העדפות חניכים
        [HttpGet]
        [Route("api/preferenceApprentice/GetAllApprenticePreference")]
        public RequestResult GetAllApprenticePreference()
        {
            return db.GettAllPreferenceApprentice();
        }
        //קבלת כל עדיפוית חניך
        [HttpGet]
        [Route("api/preferenceApprentice/GetApprenticePreference/{apprenticeId}")]
        public RequestResult GetApprenticePreference(int apprenticeId)
        {
            return db.GetAllPreferencesApprentice(apprenticeId);
        }
        // POST: api/PreferenceApprentice
        public void Post([FromBody]string value)
        {
            //אין צורך בזה בוצע כבר בהכנסת החניך
        }
        //עדכון העדפת חניך - שקופית 11
        //PUT : api/PreferenceApprentice/5/5/5
        // PUT: api/tutorCharacterizationConstraint/Put/5/1/1
        [HttpPut]
        [Route("api/preferenceApprentice/updatePreferenceApprentice")]
        public void updatePreferenceApprentice(PreferenceApprenticeDto preferenceApprentice)
        {
            db.UpdateApprenticePreference(preferenceApprentice);
        }
        // DELETE: api/PreferenceApprentice/5
        public void Delete(int id)
        {
        }
    }
}
