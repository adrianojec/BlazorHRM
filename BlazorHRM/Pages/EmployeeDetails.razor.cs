using System;
using BlazorHRM.Models;
using BlazorHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Pages
{
  public partial class EmployeeDetails
  {
    [Parameter]
    public String EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    protected override Task OnInitializedAsync()
    {
      Employee = MockDataService.Employees.FirstOrDefault(employee => employee.EmployeeId == int.Parse(EmployeeId));

      return base.OnInitializedAsync();
    }
  }
}

