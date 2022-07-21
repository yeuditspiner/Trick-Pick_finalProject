using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public class PreferenceTutorDto
    {
        public int PreferenceForTutorID { get; set; }
        public int PreferenceID { get; set; }
        public int TutorID { get; set; }
        public Nullable<int> Status { get; set; }
        public PreferenceTutorTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceTutorDto, PreferenceTutorTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceTutorTbl>(this);
        }
        public static PreferenceTutorDto DalToDto(PreferenceTutorTbl preferenceTutor)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceTutorTbl, PreferenceTutorDto>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceTutorDto>(preferenceTutor);
        }
    }
}
