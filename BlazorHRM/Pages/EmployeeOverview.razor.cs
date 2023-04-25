using System;
using BlazorHRM.Models;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Pages
{
  public partial class EmployeeOverview
  {
    public List<Employee>? Employees { get; set; } = default!;

    private Employee? _selectedEmployee;

    protected override void OnInitialized()
    {
      Employees = MockDataService.Employees;
    }

    public void ShowQuickViewModal(Employee selectedEmployee)
    {
      _selectedEmployee = selectedEmployee;
    }


  }
}

