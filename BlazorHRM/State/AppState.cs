using System;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.State
{
  public class AppState
  {
    public int MessageCount { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
  }
}

