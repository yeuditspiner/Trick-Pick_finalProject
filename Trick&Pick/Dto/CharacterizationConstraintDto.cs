using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class CharacterizationConstraintDto
    {
        public int CharacterizationConstraintsId { get; set; }
        public int ConstarintId { get; set; }
        public Nullable<bool> IsOpposit { get; set; }
        public string Value { get; set; }


        public CharacterizationConstraintsTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CharacterizationConstraintDto, CharacterizationConstraintsTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<CharacterizationConstraintsTbl>(this);
        }
        public static CharacterizationConstraintDto DalToDto(CharacterizationConstraintsTbl characterizationConstraint)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CharacterizationConstraintsTbl, CharacterizationConstraintDto>());
            var mapper = new Mapper(config);
            return mapper.Map<CharacterizationConstraintDto>(characterizationConstraint);
        }
    }
}
