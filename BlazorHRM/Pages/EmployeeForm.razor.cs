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

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string? EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();

    public List<Country> Countries { get; set; } = new List<Country>();

    public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

    protected string Message = string.Empty;

    protected string StatusClass = string.Empty;

    protected bool Saved;

    protected async override Task OnInitializedAsync()
    {
      Saved = false;
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

    protected async Task HandleValidSubmit()
    {
      if (Employee.EmployeeId == 0)
      {
        var newEmployee = await EmployeeDataService.Create(Employee);
        handleNewEmployee(newEmployee);
      }
      else
      {
        await EmployeeDataService.Update(Employee);
        StatusClass = "alert-success";
        Message = "Employee updated successfully.";
        Saved = true;
      }
    }

    protected async Task HandleInvalidSubmit()
    {
      StatusClass = "alert-danger";
      Message = "There are some validation errors. Please try again.";
    }

    protected async Task DeleteEmployee()
    {
      await EmployeeDataService.Delete(Employee.EmployeeId);
      StatusClass = "alert-success";
      Message = "Deleted Successfully";
      Saved = true;
    }

    protected void NavigateToOverview()
    {
      NavigationManager.NavigateTo("/employee-overview");
    }

    private void handleNewEmployee(Employee? newEmployee)
    {
      if (newEmployee != null)
      {
        StatusClass = "alert-success";
        Message = "New employee added successfully.";
        Saved = true;
      }
      else
      {
        StatusClass = "alert-danger";
        Message = "Something went wrong when adding the new employee. Please try again.";
        Saved = false;
      }
    }
  }
}

