using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Api.Models
{
  public interface ICountryRepository
  {
    IEnumerable<Country> GetAllCountries();
    Country GetCountryById(int countryId);
  }
}
