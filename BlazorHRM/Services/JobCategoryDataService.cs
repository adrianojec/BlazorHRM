using System;
using System.Text.Json;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Services
{
  public class JobCategoryDataService : IJobCategoryDataService
  {
    private readonly HttpClient _httpClient;

    public JobCategoryDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<List<JobCategory>> GetAll()
    {
      return await JsonSerializer.DeserializeAsync<List<JobCategory>>(await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<JobCategory> GetById(int jobCategoryId)
    {
      return await JsonSerializer.DeserializeAsync<JobCategory>(await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

    }
  }
}

