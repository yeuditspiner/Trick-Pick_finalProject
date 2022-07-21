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
    public class PattrenConstaraintController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/PattrenConstaraint
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //קבלת תבנית אילוץ מסוים
        [HttpGet]
        [Route("api/PattrenConstaraint/GetPattrenConstaraintByConstarintId/{constarintId}")]
        public RequestResult GetPattrenConstaraintByConstarint(int constarintId)
        {
            return db.GetPattrenConstaraintByConstarintId(constarintId);
        }
        //קבלת מזהה אילוץ עפי שם אילוץ
        [HttpGet]
        [Route("api/PattrenConstaraint/GetConstraintIdByName/{constarintName}")]

        public RequestResult GetConstraintIdByName(string constarintName)
        {
            return db.GetConstraintIdByName(constarintName);
        }
        //הוספת תבנית אילוץ - שקופית 7
        // POST: api/PattrenConstaraint
        [HttpPost]
        [Route("api/patternConstraint/Post")]
        public void Post(PattrenConstaraintDto pattrenConstarainte)
        {
            db.AddPattrenConstaraint(pattrenConstarainte);
        }
        // PUT: api/PattrenConstaraint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PattrenConstaraint/5
        public void Delete(int id)
        {
        }
    }
}
