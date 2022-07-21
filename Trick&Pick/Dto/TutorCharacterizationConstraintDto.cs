using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
 public   class TutorCharacterizationConstraintDto
    {
        public int TutorCharacterizationConstrainId { get; set; }
        public int CharacterizationConstarintId { get; set; }
        public int TutorId { get; set; }
        public Nullable<int> Status { get; set; }
      

        public TutorCharacterizationConstraintTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorCharacterizationConstraintDto,TutorCharacterizationConstraintTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorCharacterizationConstraintTbl>(this);
        }
        public static TutorCharacterizationConstraintDto DalToDto(TutorCharacterizationConstraintTbl tutorCharacterizationConstraint)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorCharacterizationConstraintTbl, TutorCharacterizationConstraintDto>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorCharacterizationConstraintDto>(tutorCharacterizationConstraint);

        }
    }
}
