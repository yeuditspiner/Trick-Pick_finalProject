using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public  class PlacementDto
    {
        public int PlacementID { get; set; }
        public string PlacementName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> NumberOfCandidatesForApprentice { get; set; }
        public Nullable<int> NumberOfCandidatesForTutor { get; set; }

        public PlacementTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PlacementDto, PlacementTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<PlacementTbl>(this);
        }
        public static PlacementDto DalToDto(PlacementTbl placemnt)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<PlacementTbl, PlacementDto>());
            var mapper = new Mapper(config);
            return mapper.Map<PlacementDto>(placemnt);
        }
    }
}
