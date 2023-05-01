using System;
using System.Text.Json;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Services
{
  public class CountryDataService : ICountryDataService
  {
    private readonly HttpClient _httpClient;

    public CountryDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<List<Country>> GetAll()
    {
      return await JsonSerializer.DeserializeAsync<List<Country>>(await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
    }

    public async Task<Country> GetById(int countryId)
    {
      return await JsonSerializer.DeserializeAsync<Country>(await _httpClient.GetStreamAsync($"api/country/{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
    }
  }
}

