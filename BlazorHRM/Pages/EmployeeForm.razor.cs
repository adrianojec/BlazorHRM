using System;
using BlazorHRM.Services;
using BlazorHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Pages
{
  public partial class EmployeeForm
  {
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public ICountryDataService? CountryDataService { get; set; }

    [Inject]
    public IJobCategoryDataService? JobCategoryDataService { get; set; }

    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<Country> Countries { get; set; } = new List<Country>();

    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

    protected async override Task OnInitializedAsync()
    {
      if (EmployeeId != null)
      {
        Employee = await EmployeeDataService.GetById(int.Parse(EmployeeId));
      }
      else
      {
        Employee = new Employee
        {
          CountryId = 1,
          JobCategoryId = 1,
          BirthDate = DateTime.Now,
          JoinedDate = DateTime.Now
        };
      }
      Countries = await CountryDataService.GetAll();
      JobCategories = await JobCategoryDataService.GetAll();
    }
  }
}

