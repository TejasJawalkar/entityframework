using DemoTask.Data;
using DemoTask.Entity;
using DemoTask.Entity.Models;
using DemoTask.Entity.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Xml.Linq;

namespace DemoTask.Core
{
  public class CrudOperationServices : ICrudOperationServices
  {
    private readonly ApplicationDbContext _ApplicationDbContext;
    public CrudOperationServices(ApplicationDbContext ApplicationDbContext)
    {
      _ApplicationDbContext = ApplicationDbContext;
    }

    
    public async Task<ListOutput> GetAllData(Response response)
    {
      ListOutput listOutput = new ListOutput();
      listOutput.employees = new List<EmployeeOuput>();
      try
      {
        listOutput.employees =await (from e in _ApplicationDbContext.Employees
                                select new EmployeeOuput
                                {
                                  E_Id = e.E_Id,
                                  F_Name = e.F_Name,
                                  M_Name = e.M_Name,
                                  L_Name = e.L_Name,
                                  Mobile = e.Mobile,
                                  Address = e.Address,
                                }).ToListAsync();
      }
      catch (Exception ex)
      {
        response.Message += ex.Message;
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return listOutput;
    }

   
    public async Task<EmployeeOuput> GetData(Int64 Id, Response response)
    {
      EmployeeOuput? employees = new EmployeeOuput();
      try
      {
        employees = await (from e in _ApplicationDbContext.Employees
                     where e.E_Id==Id
                     select new EmployeeOuput
                     {
                       E_Id = e.E_Id,
                       F_Name = e.F_Name,
                       M_Name = e.M_Name,
                       L_Name = e.L_Name,
                       Mobile = e.Mobile,
                       Address = e.Address,
                     }).FirstOrDefaultAsync();
      }
      catch (Exception ex)
      {
        response.Message += ex.Message;
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return employees;
    }

   
    public async Task AddNewData(EmployeeInput employeeInput, Response response)
    {
      try
      {
        var employee = new EmployeeEntity
        {
          F_Name = employeeInput.F_Name,
          M_Name = employeeInput.M_Name,
          L_Name = employeeInput.L_Name,
          Mobile=employeeInput.Mobile,
          Address=employeeInput.Address
        };

        await _ApplicationDbContext.Employees.AddAsync(employee);
        await _ApplicationDbContext.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        response.Message +=ex.Message ;
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
    }

    public async Task UpdateEmployee(EmployeeInput employeeInput, Response response)
    {
      try
      {
        var employee = await _ApplicationDbContext.Employees.Where(e => e.E_Id == employeeInput.E_Id).FirstOrDefaultAsync<EmployeeEntity>();
        if(employee!=null)
        {
          employee.F_Name = employeeInput.F_Name;
          employee.M_Name = employeeInput.M_Name;
          employee.L_Name = employeeInput.L_Name;
          employee.Mobile = employeeInput.Mobile;
          employee.Address = employeeInput.Address;
          await _ApplicationDbContext.SaveChangesAsync();
        }
        else
        {
          response.Message += "Norecord Found Wih given Id";
          response.StatusCode = Entity.Response.StatusCode.NotFound;
        }
      }
      catch (Exception ex)
      {
        response.Message += ex.Message;
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
    }

    public async Task DeleteData(long Id, Response response)
    {
      try
      {
        var employee =await _ApplicationDbContext.Employees.Where(e => e.E_Id == Id).FirstOrDefaultAsync<EmployeeEntity>();
        if (employee != null)
        {
          _ApplicationDbContext.Employees.Remove(employee);
          await _ApplicationDbContext.SaveChangesAsync();
        }
        else
        {
          response.StatusCode = Entity.Response.StatusCode.NotFound;
          response.Message += "Employee Not Found With Id";
        }
      }
      catch (Exception ex)
      {
        response.Message += ex.Message;
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
    }
  }
}
