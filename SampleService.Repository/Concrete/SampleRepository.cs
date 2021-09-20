using System;
using System.Collections.Generic;
using SampleService.Model.Domain;
using SampleService.Repository.Interface;

namespace SampleService.Repository.Concrete
{
    public class SampleRepository : ISampleRepository
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee(){ Id=1, Name="Ankit"}
            };
        }
    }
}
