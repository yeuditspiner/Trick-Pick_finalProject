using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class AreaDto
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int CityId { get; set; }
        public AreaTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<AreaDto, AreaTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<AreaTbl>(this);
        }
        public static AreaDto DalToDto(AreaTbl area)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<AreaTbl, AreaDto>());
            var mapper = new Mapper(config);
            return mapper.Map<AreaDto>(area);
        }
    }
}
