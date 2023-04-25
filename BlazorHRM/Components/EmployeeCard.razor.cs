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
  }
}

