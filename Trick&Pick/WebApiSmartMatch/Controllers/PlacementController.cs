using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Bll;
using Dto;

namespace WebApiSmartMatch.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlacementController : ApiController
    {
        DbClass db = new DbClass();

        [HttpGet]
        [Route("api/placement/GetBy/{placementId}")]
        public RequestResult GetBy(int placementId)
        {
            return db.GetPlacementById(placementId);
        }
        [HttpGet]
        [Route("api/placement/GetByName/{placementName}")]
        public RequestResult GetByName(string  placementName)
        {
            return db.GetPlacementByName(placementName);
        }
        //ביצוע שיבוץוטעארק'63
        [HttpPost]
        [Route("api/placement/GetPlacement")]

        public RequestResult GetPlacement([FromUri]int placementId,[FromBody] List<int> lstAreas)
        {
           
            return db.GetPlacement(lstAreas, placementId);
        }
        //כל שמות השיבוצים
        [HttpGet]
        [Route("api/placement/GetAllPlacement")]
        public RequestResult GetAllPlacement()
        {
            return db.GetAllPlacement();
        }
        //עבור הטולטיפ
        [HttpGet]
        [Route("api/placement/GetTolTip/{placementId}")]
        public RequestResult GetTolTip(int placementId)
        {
            return db.finalForTolTip(placementId);
        }
        //קבלת החונכים שבשיבוץ
        [HttpGet]
        [Route("api/placement/GetTutorsResult/{placementId}")]
        public RequestResult GetTutorsResult(int placementId)
        {
            return db.GetResultTutorToTable(placementId);
        }
       
        //קבלת הניקודים שבשיבוץ
        [HttpGet]
        [Route("api/placement/GetScoreResult/{placementId}")]
        public RequestResult GetScoreResult(int placementId)
        {
            return db.GetScoreResultToTable(placementId);
        }
    
        //קבלת החניכים שבשיבוץ
        [HttpGet]
        [Route("api/placement/GetApprenticeResult/{placementId}")]
        public RequestResult GetApprenticeResult(int placementId)
        {
            return db.GetResultApprenticeToTable(placementId);
        }
        //הוספת שיבוץ חדש
        // POST: api/Placement
        [HttpPost]
        [Route("api/placement/Post/{placementDto.PlacementID,placementDto.PlacementName,placementDto.Date}")]
        public void Post(PlacementDto placementDto)
        {
            db.AddPlacement(placementDto);
        }

        // PUT: api/Placement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Placement/5
        public void Delete(int id)
        {
        }
    }
}
