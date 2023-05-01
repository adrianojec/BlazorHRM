using System;
using BlazorHRM.Models;
using BlazorHRM.Services;
using BlazorHRM.Shared.Domain;
using BlazorHRM.State;
using Microsoft.AspNetCore.Components;

namespace BlazorHRM.Pages
{
  public partial class EmployeeOverview
  {
    [Inject]
    public IEmployeeDataService? EmployeeDataService { get; set; }

    [Inject]
    public AppState? AppState { get; set; }

    public List<Employee>? Employees { get; set; } = default!;

    private Employee? _selectedEmployee;

    private string Title = "Employee Overview";

    protected override async Task OnInitializedAsync()
    {
      Employees = await EmployeeDataService.GetAll();
    }

    public void ShowQuickViewModal(Employee selectedEmployee)
    {
      _selectedEmployee = selectedEmployee;
    }


  }
}

