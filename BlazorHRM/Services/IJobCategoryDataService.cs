using System;
using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Services
{
  public interface IJobCategoryDataService
  {
    Task<List<JobCategory>> GetAll();
    Task<JobCategory> GetById(int jobCategoryId);
  }
}

