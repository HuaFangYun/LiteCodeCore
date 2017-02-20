using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCode.ViewModels.Mapper
{
    public static class EntityMapper
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }
    }
}
