using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class PreferenceDto
    {
        public int PreferenceID { get; set; }
        public string PreferenceName { get; set; }
        public PreferenceTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceDto, PreferenceTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceTbl>(this);
        }
        public static PreferenceDto DalToDto(PreferenceTbl city)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PreferenceTbl, PreferenceDto>());
            var mapper = new Mapper(config);
            return mapper.Map<PreferenceDto>(city);
        }
    }
}
