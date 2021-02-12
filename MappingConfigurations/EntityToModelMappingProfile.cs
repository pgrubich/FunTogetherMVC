using AutoMapper;
using FunTogether.Data;
using FunTogether.Models;
using FunTogether.Filters;
using System.Collections.Generic;

namespace FunTogether.MappingConfigurations
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Activity, ActivityViewModel>();
            CreateMap<ActivityViewModel, Activity>();

            CreateMap<Activity, ActivityIndexViewModel>();
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>)).ConvertUsing(typeof(PaginatedListConverter<,>));
        }

        public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>> where TSource : class where TDestination : class
        {
            public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
            {
                var collection = context.Mapper.Map<List<TSource>, List<TDestination>>(source);

                return new PaginatedList<TDestination>(collection, source.Count, source.PageNumber, source.PageSize, source.TotalPages);
            }
        }
    }
}
