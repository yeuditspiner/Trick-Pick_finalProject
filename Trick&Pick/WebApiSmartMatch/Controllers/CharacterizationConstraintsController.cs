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

    public class CharacterizationConstraintsController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/CharacterizationConstraints
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CharacterizationConstraints/5
        public string Get(int id)
        {
            return "value";
        }
        //קבלת ערכי אילוץ constraintId   - עבור שקופית מס 6
        [HttpGet]
        [Route("api/characterizationConstraints/GetCharacterizationConstraints/{constraintId}")]
        public RequestResult GetCharacterizationConstraints(int constraintId)
        {
            return db.GetCharacterizationByConstraint(constraintId);
        }
        //הוספת ערך אילוץ חדש - שקופית 7
        // POST: api/CharacterizationConstraints
        [HttpPost]
        [Route("api/characterizationConstraints/Post")]
        public void Post(CharacterizationConstraintDto characterizationConstraints)
        {
            db.AddAddCharacterizationConstraints(characterizationConstraints);
        }

        // PUT: api/CharacterizationConstraints/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CharacterizationConstraints/5
        public void Delete(int id)
        {
        }
    }
}
