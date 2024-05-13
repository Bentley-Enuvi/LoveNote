using AutoMapper;
using LoveNote_Chat.Server.Model;
using LoveNote_Chat.Server.Model.DTOs;

namespace LoveNote_Chat.Server
{
    public class MappingConfig
    {
        public static MapperConfiguration MapsReg()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AppUserDto, AppUser>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
