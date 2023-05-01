using System;
using BlazorHRM.Models;
using BlazorHRM.Services;
using BlazorHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Pages
{
  public partial class EmployeeDetails
  {
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Parameter]
    public String EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Employee = await EmployeeDataService.GetById(int.Parse(EmployeeId));
    }
  }
}

