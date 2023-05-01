using System;
using System.Text;
using System.Text.Json;
using BlazorHRM.Shared.Domain;
using BlazorHRM.State;

namespace BlazorHRM.Services
{
  public class EmployeeDataService : IEmployeeDataService
  {
    private readonly HttpClient _httpClient;

    public EmployeeDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<Employee> Create(Employee employee)
    {
      var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync("api/employee", employeeJson);

      if (response.IsSuccessStatusCode)
      {
        return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
      }

      return null;
    }

    public async Task<List<Employee>> GetAll()
    {
      return await JsonSerializer.DeserializeAsync<List<Employee>>(
        await _httpClient.GetStreamAsync($"api/employee"),
        new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });

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

    public async Task Update(Employee employee)
    {
      var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
      await _httpClient.PutAsync("api/employee", employeeJson);
    }

    public Task Delete(int employeeId)
    {
      throw new NotImplementedException();
    }

  }
}

