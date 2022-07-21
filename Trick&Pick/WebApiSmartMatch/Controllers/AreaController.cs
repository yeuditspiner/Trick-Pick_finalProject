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
    public class AreaController : ApiController
    {
        // GET: api/Area
        DbClass db = new DbClass();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public RequestResult Get()
        {
            return db.GettAllArea();
        }

        // GET: api/Area/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Area
        public void Post(AreaDto areaDto)
        {
            db.AddArea(areaDto);
        }

        // PUT: api/Area/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Area/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        [Route("api/area/GetAreaByCityId/{CityId}")]
        public RequestResult GetAreaByCityId(int cityId)
        {
            
            return db.GetAreasByCity(cityId);
        }
    }
}
