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
    public class TutorCharacterizationConstraintController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/TutorCharacterizationConstraint
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TutorCharacterizationConstraint/5
        public string Get(int id)
        {
            return "value";
        }
        //קבלת כל ערכי אילוץ חונך
        [HttpGet]
        [Route("api/tutorCharacterizationConstraint/GetAllCharacterizationConstraint/{tutorId}")]
        public RequestResult GetAllCharacterizationConstraint(int tutorId)
        {
            return db.GetTutorCharacterizationConstraint(tutorId);
        }
        //קבלת ערך אילוץ חונך 
        [HttpGet]
        [Route("api/tutorCharacterizationConstraint/GetCharacterizationTutor/{tutorId}/{constaraintTutorId}/{constarintId}")]
        public RequestResult GetCharacterizationTutor(int tutorId, int constaraintTutorId, int constarintId)
        {
            return db.GetCharacterizationConstraintByTutor(tutorId, constaraintTutorId, constarintId);
        }
        // POST: api/TutorCharacterizationConstraint
        public void Post([FromBody]string value)
        {
        }

        //עדכון מאפיין אילוץ חונך -שקופית 6
        // PUT: api/tutorCharacterizationConstraint/Put/5/1/1
        [HttpPut]
        [Route("api/tutorCharacterizationConstraint/Put")]
        public void Put( TutorCharacterizationConstraintDto tutorCharacterizationConstraints)
        {
            db.UpdatTutorCharacterizationConstraint(tutorCharacterizationConstraints);

        }

        // DELETE: api/TutorCharacterizationConstraint/5
        public void Delete(int id)
        {
        }
    }
}
