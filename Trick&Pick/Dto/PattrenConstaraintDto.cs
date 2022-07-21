using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public   class PattrenConstaraintDto
    {
        public int ConstraintPatternId { get; set; }
        public int ConstarintId { get; set; }
    
        public int ConstraintPatternType { get; set; }

        public PattrenConstaraintTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PattrenConstaraintDto, PattrenConstaraintTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<PattrenConstaraintTbl>(this);
        }
        public static PattrenConstaraintDto DalToDto(PattrenConstaraintTbl pattrenConstaraint)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PattrenConstaraintTbl, PattrenConstaraintDto>());
            var mapper = new Mapper(config);
            return mapper.Map<PattrenConstaraintDto>(pattrenConstaraint);
        }
    }
}
