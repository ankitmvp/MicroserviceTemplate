using System;
using System.Collections.Generic;

namespace SampleService.Common.Interface
{
    public interface IMapperProvider
    {
        TDestination Map<TDestination>(object source);
        List<TDestination> Map<TDestination>(IEnumerable<object> source);
    }
}
