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

    public class CharacterizationConstraintApprenticeController : ApiController
    {

        DbClass db= new DbClass();
        // GET: api/CharacterizationConstraintApprentice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CharacterizationConstraintApprentice/5
        public string Get(int id)
        {
            return "value";
        }

        //קבלת כל ערכי אילוץ חניך
        [HttpGet]
        [Route("api/characterizationConstraintApprentice/GetAllCharacterizationConstraint/{apprenticeId}")]
        public RequestResult GetAllCharacterizationConstraint(int apprenticeId)
        {
            return db.GetApprenticeCharacterizationConstraint(apprenticeId);
        }
        //קבלת ערך אילוץ חניך
        [HttpGet]
        [Route("api/characterizationConstraintApprentice/GetCharacterizationApprentice/{apprenticeId}/{constaraintApprenticeId}/{constarintId}")]
        public RequestResult GetCharacterizationApprentice(int apprenticeId, int constaraintApprenticeId,int constarintId)
        {
            return db.GetCharacterizationConstraintByApprentice(apprenticeId, constaraintApprenticeId, constarintId);
        }
        // POST: api/CharacterizationConstraintApprentice
        public void Post([FromBody]string value)
        {
        }
        //עדכון מאפיין אילוץ חניך -שקופית 6
        // PUT: api/CharacterizationConstraintApprentice/Put/5/1/1
        [HttpPut]
        [Route("api/CharacterizationConstraintApprentice/Put")]
        public void Put( CharacterizationConstraintApprenticeDto  CharacterizationConstraintApprentice)
        {
            db.UpdateApprenticeCharacterizationConstraint( CharacterizationConstraintApprentice);

        }

        // DELETE: api/CharacterizationConstraintApprentice/5
        public void Delete(int id)
        {
        }
    }
}
