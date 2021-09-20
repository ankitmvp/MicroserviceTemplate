using System;
using System.Collections.Generic;
using SampleService.Model.Domain;

namespace SampleService.Repository.Interface
{
    public interface ISampleRepository
    {
        List<Employee> GetEmployees();
    }
}
