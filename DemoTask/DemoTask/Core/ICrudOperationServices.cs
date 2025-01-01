using DemoTask.Entity;
using DemoTask.Entity.Response;

namespace DemoTask.Core
{
  public interface ICrudOperationServices
  {
    public Task<ListOutput> GetAllData(Response response);
    public Task<EmployeeOuput> GetData(Int64 Id, Response response);
    public Task AddNewData(EmployeeInput employeeInput, Response response);
    public Task UpdateEmployee(EmployeeInput employeeInput, Response response);
    public Task DeleteData(Int64 Id, Response response);
  }
}
