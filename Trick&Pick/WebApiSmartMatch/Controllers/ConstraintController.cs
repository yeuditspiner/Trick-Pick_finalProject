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
    public class ConstraintController : ApiController
    {
        DbClass db = new DbClass();
   
        //קבלת אילוצי שיבוץ - עבור שקופית 6
        [HttpGet]
        [Route("api/Constraints/GetConstraintByPlacement/{placementId}")]
        public RequestResult GetConstraintByPlacement(int placementId)
        {
            return db.GetConstarintsByPlacement(placementId);
        }
        //הוספת אילוץ חדש - שקופית 6
        // POST: api/Constraint
        [HttpPost]
        [Route("api/constraint/Post")]
        public RequestResult Post( ConstraintDto constraint)
        {
            db.AddConstraint(constraint);
            return db.GetConstraintIdByName(constraint.ConstraintName);
        }

        // PUT: api/Constraint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Constraint/5
        public void Delete(int id)
        {
        }
    }
}
