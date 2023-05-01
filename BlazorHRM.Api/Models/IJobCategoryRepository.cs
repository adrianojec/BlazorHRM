using BlazorHRM.Shared.Domain;

namespace BlazorHRM.Api.Models
{
  public interface IJobCategoryRepository
  {
    IEnumerable<JobCategory> GetAllJobCategories();
    JobCategory GetJobCategoryById(int jobCategoryId);
  }
}
