using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class ConstraintDto
    {
        public int ConstraintID { get; set; }
        public string ConstraintName { get; set; }
        public int Placement { get; set; }
        public ConstraintTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<ConstraintDto, ConstraintTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<ConstraintTbl>(this);
        }
        public static ConstraintDto DalToDto(ConstraintTbl constraint)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<ConstraintTbl, ConstraintDto>());
            var mapper = new Mapper(config);
            return mapper.Map<ConstraintDto>(constraint);
        }
    }
}
