using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class CharacterizationConstraintApprenticeDto
    {
        public int ApprenticeCharacterizationConstraintId { get; set; }
        public int ApprenticeId { get; set; }
        public int CharacterizationConstraintId { get; set; }
        public Nullable<int> Status { get; set; }
        public CharacterizationConstraintApprenticeTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CharacterizationConstraintApprenticeDto, CharacterizationConstraintApprenticeTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<CharacterizationConstraintApprenticeTbl>(this);
        }
        public static CharacterizationConstraintApprenticeDto DalToDto(CharacterizationConstraintApprenticeTbl characterizationConstraintApprentice)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<CharacterizationConstraintApprenticeTbl, CharacterizationConstraintApprenticeDto>());
            var mapper = new Mapper(config);
            return mapper.Map<CharacterizationConstraintApprenticeDto>(characterizationConstraintApprentice);
        }
    }
}
