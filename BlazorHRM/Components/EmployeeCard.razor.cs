using System;
using BlazorHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Components
{
  public partial class EmployeeCard
  {
    [Parameter]
    public Employee Employee { get; set; } = default!;

    [Parameter]
    public EventCallback<Employee> OnClickQuickView { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
      if (string.IsNullOrEmpty(Employee.LastName))
      {
        throw new Exception("Last name can't be empty");
      }
    }

    public void NavigateToEmployeeDetails(int employeeId)
    {
      NavigationManager.NavigateTo($"/employee-overview/{employeeId}");
    }

  }
}

