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
    public class TutorController : ApiController
    {
        // GET: api/Tutor
        DbClass db = new DbClass();
        
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //קבלת כל החונכים
        public RequestResult Get()
        {
            return db.GettAllTutor();
        }
        //קבלת החונכים שגרים באחד מן האזורים שבליסט ושייכים לשיבוץ פלסמנטאידי     
        public RequestResult Get(List<int>lstArea,int placementId)
        {
            return db.GetTutorsByArea(lstArea,placementId);
        }


        // GET: api/Tutor/5
        //public string Get()
        //{
        //    return "value";
        //}

        //הוספת חונך  - שקופית 9
        // POST: api/Tutor
        public void Post(TutorDto value)
        {
            db.AddTutor(value);
        }

        // PUT: api/Tutor/5
        public void Put(int id, TutorDto value)
        {
        }

        // DELETE: api/Tutor/5
        public void Delete(TutorDto value)
        {
            
        }
        [HttpGet]
        [Route("api/Tutor/GetTutorByName/{tutorName}")]
        public string GetTutorByName(string tutorName)
        {
            var x= db.GetTutorByName(tutorName).Data.ToString();
            return x;
        }
        //קבלת חונך עפי שם משתמש וסיסמא
        [HttpGet]
        [Route("api/Tutor/GetTutorByUserNameAndPassword/{tutorName}/{password}")]
        public RequestResult GetTutorByUserNameAndPassword(string tutorName, string password)
        {
            return db.GetTutorByLogIn(tutorName, password);
        }
    }
}
