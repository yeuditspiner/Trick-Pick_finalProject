using Bll;
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
    public class TutorForApprenticeController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/TutorForApprentice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //קבלת פרטי זוג שיצא משובץ - שקופית 10
        [HttpGet]
        [Route("api/TutorForApprentice/GetResultProperty/{tutorId}/{apprenticeId}")]
        public string  GetResultProperty(int tutorId,int apprenticeId)
        {
          int mark = (int)db.GetMarkForTutorandApprentice(apprenticeId, tutorId);
          string  result= db.GetTutorById(tutorId).Data + " ";
          result += db.GetApprenticeById(apprenticeId).Data;
            return result + " the match Level is: " + mark.ToString();
        }
        //קבלת תוצאת שיבוץ עי קוד שיבוץ
        [HttpGet]
        [Route("api/TutorForApprentice/GetTutorForApprenticeByPlacement/{placementId}")]
        public RequestResult GetTutorForApprenticeByPlacement(int placementId)
        {
            return db.GetTutorFoeApprenticeByPlacement(placementId);
        }
        // POST: api/TutorForApprentice
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TutorForApprentice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TutorForApprentice/5
        public void Delete(int id)
        {
        }
    }
}
