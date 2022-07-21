using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
  public   class TutorForApprenticeDto
    {
        public int TutorForApprenticeId { get; set; }
        public int PlacementID { get; set; }
        public int TutorID { get; set; }
        public int ApprenticeID { get; set; }
        public Nullable<int> MatchLevelScore { get; set; }

        public virtual ApprenticeTbl ApprenticeTbl { get; set; }
        public virtual PlacementTbl PlacementTbl { get; set; }
        public virtual TutorTbl TutorTbl { get; set; }

        public TutorForApprenticeDto( int tutorID, int apprenticeID, int? matchLevelScore)
        {
            TutorID = tutorID;
            ApprenticeID = apprenticeID;
            MatchLevelScore = matchLevelScore;
            
        }

        public TutorForApprenticeDto()
        {
        }

        public TutorForApprenticeTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorForApprenticeDto, TutorForApprenticeTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorForApprenticeTbl>(this);
        }
        public static TutorForApprenticeDto DalToDto(TutorForApprenticeTbl tutorforapprentice)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<TutorForApprenticeTbl, TutorForApprenticeDto>());
            var mapper = new Mapper(config);
            return mapper.Map<TutorForApprenticeDto>(tutorforapprentice);
        }
    }
}
