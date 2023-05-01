using System;
using System.Text.Json;
using BlazorHRM.Shared.Domain;
using BlazorHRM.State;

namespace BlazorHRM.Services
{
  public class EmployeeDataService : IEmployeeDataService
  {
    private readonly HttpClient _httpClient;
    private readonly AppState _appState;

    public EmployeeDataService(HttpClient httpClient, AppState appState)
    {
      _httpClient = httpClient;
      _appState = appState;
    }

    public Task<Employee> Create(Employee employee)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Employee>> GetAll()
    {
      var employees = await JsonSerializer.DeserializeAsync<List<Employee>>(
        await _httpClient.GetStreamAsync($"api/employee"),
        new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });
      _appState.Employees = employees;
      return employees;

    }

    public async Task<Employee> GetById(int employeeId)
    {
      return await JsonSerializer.DeserializeAsync<Employee>(
        await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
        new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });
    }

    public Task Update(Employee employee)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int employeeId)
    {
      throw new NotImplementedException();
    }

  }
}

