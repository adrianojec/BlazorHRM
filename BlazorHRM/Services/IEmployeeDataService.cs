using System;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Services
{
  public interface IEmployeeDataService
  {
    Task<Employee> Create(Employee employee);
    Task<List<Employee>> GetAll();
    Task<Employee> GetById(int employeeId);
    Task Update(Employee employee);
    Task Delete(int employeeId);
  }
}

