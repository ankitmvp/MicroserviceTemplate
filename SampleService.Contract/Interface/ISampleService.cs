using System;
using System.Collections.Generic;
using SampleService.Contract.Contract;

namespace SampleService.Contract.Interface
{
    public interface ISampleService
    {
        List<EmployeeDto> GetEmployees();
    }
}
