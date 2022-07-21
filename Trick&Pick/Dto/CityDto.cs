using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public CityTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CityDto, CityTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<CityTbl>(this);
        }
        public static CityDto DalToDto(CityTbl city)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CityTbl, CityDto>());
            var mapper = new Mapper(config);
            return mapper.Map<CityDto>(city);
        }
    }
}
