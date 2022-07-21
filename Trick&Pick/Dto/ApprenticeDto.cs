using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public  class ApprenticeDto
    {
        public int ApprenticeID { get; set; }
        public string ApprenticeName { get; set; }
        public Nullable<int> PlacementId { get; set; }
        public int AreaID { get; set; }
        public string Password { get; set; }
        public string ApprenticePhone { get; set; }
        public int CityId { get; set; }
        public decimal ApprenticeAga { get; set; }




        public ApprenticeTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<ApprenticeDto, ApprenticeTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<ApprenticeTbl>(this);
        }
        public static ApprenticeDto DalToDto(ApprenticeTbl apprentice)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<ApprenticeTbl, ApprenticeDto>());
            var mapper = new Mapper(config);
            return mapper.Map<ApprenticeDto>(apprentice);
        }

    }
}
