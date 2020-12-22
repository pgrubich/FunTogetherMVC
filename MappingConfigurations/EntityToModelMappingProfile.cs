using AutoMapper;
using FunTogether.Data;
using FunTogether.Models;

namespace FunTogether.MappingConfigurations
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Activity, ActivityViewModel>();
            CreateMap<ActivityViewModel, Activity>();
            //           CreateMap<User, UserViewModel>();
        }
    }
}
