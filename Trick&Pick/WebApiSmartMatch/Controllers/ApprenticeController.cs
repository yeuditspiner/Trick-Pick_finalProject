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
    public class ApprenticeController : ApiController
    {
        DbClass db = new DbClass();
        // GET: api/Apprentice
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Apprentice/5
        public RequestResult Get()
        {
            return db.GettAllApprentice();
        }

        //קבלת החניכים שגרים באחד מן האזורים שבליסט ושייכים לשיבוץ פלסמנטאידי
        //HttpGet]
        [Route("api/Apprentice/Get/{lstArea}/{placementId}")]
        public RequestResult Get(List<int> lstArea, int placementId)
        {
            return db.GetApprenticesByArea(lstArea, placementId);
        }
        //קבלת חניך עפי שם משתמש וסיסמא
        [HttpGet]
        [Route("api/apprentice/GetApprenticeByUserNameAndPassword/{apprenticeName}/{password}")]
        public RequestResult GetApprenticeByUserNameAndPassword(string apprenticeName, string password)
        {
            return db.GetApprenticeByLogIn(apprenticeName, password);
        }
        public string Get(int id)
        {
            return "value";
        }
        //הוספת חניך  - שקופית 9
        // POST: api/Apprentice
        public void Post(ApprenticeDto apprenticeDto)
        {
            db.AddApprentice(apprenticeDto);
        }

        // PUT: api/Apprentice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apprentice/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("api/Apprentice/GetApprenticeByName/{apprenticename}")]
        public string GetApprenticeByName(string apprenticename)
        {
            var x = db.GetTutorByName(apprenticename).Data.ToString();
            return x;
        }
    }
}
