using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public   class TutorDto
    {
        public int TutorID { get; set; }
        public int PlacementId { get; set; }
  
        public string TutorName { get; set; }
        public Nullable<decimal> TutorAge { get; set; }
        public string TutorPhone { get; set; }
        public int AreaID { get; set; }
        public string PasswordID { get; set; }
        public int CityId { get; set; }
        public TutorTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorDto, TutorTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorTbl>(this);
        }
        public static TutorDto DalToDto(TutorTbl tutor)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorTbl, TutorDto>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorDto>(tutor);
        }
    }
}
