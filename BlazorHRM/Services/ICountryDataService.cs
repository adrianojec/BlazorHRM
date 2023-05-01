using System;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Services
{
  public interface ICountryDataService
  {
    Task<List<Country>> GetAll();
    Task<Country> GetById(int countryId);
  }
}

