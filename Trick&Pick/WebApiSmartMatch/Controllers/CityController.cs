using Bll;
using Dto;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSmartMatch.Controllers
{

    [EnableCors(origins: "*",headers:"*",methods:"*")]
    public class CityController : ApiController
    {
        DbClass db = new DbClass();


        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route("api/city/Get")]
        public RequestResult Get()
        {

            return db.GettAllCity();
       
        }
        // GET: api/City/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/City
        public void Post(CityDto cityDto)
        {
            db.AddCity(cityDto);
        }

        // PUT: api/City/5
        public void Put( CityDto cityDto) => db.AddCity(cityDto);

        // DELETE: api/City/5
        public void Delete(CityDto cityDto)
        {
            db.DeleteCity(cityDto);

        }
        [HttpGet]
        [Route ("api/city/func/{CityId}")]
        public string func(int cityId)

        {
          return   db.GetCityById(cityId);
        }
    }
}
