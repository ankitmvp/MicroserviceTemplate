using System;
using Autofac;
using SampleService.Common.Concrete;
using SampleService.Common.Interface;

namespace SampleService.Common.Utility
{
    public class CommonAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperProvider>().As<IMapperProvider>().SingleInstance();
            base.Load(builder);
        }
    }
}
