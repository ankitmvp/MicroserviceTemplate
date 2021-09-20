using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using SampleService.Common.Interface;

namespace SampleService.Common.Concrete
{
    public class MapperProvider : IMapperProvider
    {
        private readonly IMapper _mapper;

        public MapperProvider(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public List<TDestination> Map<TDestination>(IEnumerable<object> source)
        {
            return source.Select(_mapper.Map<TDestination>).ToList();
        }
    }
}
