using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class PreferenceApprenticeDto
    {
        public int PreferenceApprenticeID { get; set; }
        public int PreferenceID { get; set; }
        public int ApprenticeID { get; set; }
        public Nullable<int> Status { get; set; }
        public PreferenceApprenticeTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceApprenticeDto, PreferenceApprenticeTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceApprenticeTbl>(this);
        }
        public static PreferenceApprenticeDto DalToDto(PreferenceApprenticeTbl preferenceApprentice)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceApprenticeTbl, PreferenceApprenticeDto>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceApprenticeDto>(preferenceApprentice);
        }
    }
}
