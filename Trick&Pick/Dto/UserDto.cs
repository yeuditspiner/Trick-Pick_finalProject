using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
 public   class UserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserTbl DtoToDal()
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<UserDto, UserTbl>());
            var mapper = new Mapper(config);
            return mapper.Map<UserTbl>(this);
        }
        public static UserDto DalToDto(UserTbl user)
        {
            var config = new MapperConfiguration(cfg =>
             cfg.CreateMap<UserTbl, UserDto>());
            var mapper = new Mapper(config);
            return mapper.Map<UserDto>(user);
        }
    }
}
