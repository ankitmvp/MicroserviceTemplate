using System;
using Autofac;
using SampleService.Repository.Concrete;
using SampleService.Repository.Interface;

namespace SampleService.Repository.Utility
{
    public class RepositoryAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleRepository>().As<ISampleRepository>();
            base.Load(builder);
        }
    }
}
