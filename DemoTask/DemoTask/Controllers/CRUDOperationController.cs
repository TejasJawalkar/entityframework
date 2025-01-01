using DemoTask.Core;
using DemoTask.Entity;
using DemoTask.Entity.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoTask.Controllers
{
  public class CRUDOperationController : Controller
  {
    private readonly ICrudOperationServices _crudOperationServices;
    public CRUDOperationController(ICrudOperationServices crudOperationServices)
    {
      _crudOperationServices = crudOperationServices;
    }

    [HttpGet]
    [Route("GetAllData")]
    [Route("/")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllData()
    {
      Response response = new Response();
      ListOutput listOutput = new ListOutput();
      try
      {
        listOutput = await _crudOperationServices.GetAllData(response);
        if (response.StatusCode != Entity.Response.StatusCode.UnKnownError)
        {
          response.Message += "All Employees";
          response.StatusCode = Entity.Response.StatusCode.Success;
        }
        response.Data = listOutput;
      }
      catch (Exception)
      {
        response.Message += "Internal Server Error, Try Again Later";
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return Json(response);
    }

    [HttpPost]
    [Route("GetData")]
    [AllowAnonymous]
    public async Task<IActionResult> GetData([FromForm]Int64 Id)
    {
      Response response = new Response();
      EmployeeOuput employeeOuput = new EmployeeOuput();
      try
      {
        employeeOuput = await _crudOperationServices.GetData(Id, response);
        if (response.StatusCode != Entity.Response.StatusCode.UnKnownError)
        {
          response.Message += "Employees Data";
          response.StatusCode = Entity.Response.StatusCode.Success;
        }
        response.Data = employeeOuput;
      }
      catch (Exception)
      {
        response.Message += "Internal Server Error, Try Again Later";
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return Json(response);
    }

    [HttpPost]
    [Route("AddNewData")]
    [AllowAnonymous]
    public async Task<IActionResult> AddNewData(EmployeeInput employeeInput)
    {
      Response response = new Response();
      try
      {
        await _crudOperationServices.AddNewData(employeeInput, response);
        if (response.StatusCode != Entity.Response.StatusCode.UnKnownError)
        {
          response.Message += "Employees Data Added";
          response.StatusCode = Entity.Response.StatusCode.Success;
        }
        response.Data = null;
      }
      catch (Exception)
      {
        response.Message += "Internal Server Error, Try Again Later";
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return Json(response);
    }

    [HttpPut]
    [Route("UpdateEmployee")]
    public async Task<IActionResult> UpdateEmployee(EmployeeInput employeeInput)
    {
      Response response = new Response();
      try
      {
        await _crudOperationServices.UpdateEmployee(employeeInput,response);
        if(response.StatusCode!=Entity.Response.StatusCode.UnKnownError && response.StatusCode!=Entity.Response.StatusCode.NotFound)
        {
          response.StatusCode = Entity.Response.StatusCode.Success;
          response.Message += "Data Updated";
        }
      }
      catch (Exception)
      {
        response.Message += "Internal Server Error, Try Again Later";
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return Json(response);
    }


    [HttpDelete]
    [Route("DeleteEmployee")]
    public async Task<IActionResult> DeleteEmployee([FromForm] Int64 Id)
    {
      Response response = new Response();
      try
      {
        await _crudOperationServices.DeleteData(Id, response);
        if (response.StatusCode != Entity.Response.StatusCode.UnKnownError && response.StatusCode != Entity.Response.StatusCode.NotFound)
        {
          response.StatusCode = Entity.Response.StatusCode.Success;
          response.Message += "Data Delete";
        }
      }
      catch (Exception)
      {
        response.Message += "Internal Server Error, Try Again Later";
        response.StatusCode = Entity.Response.StatusCode.UnKnownError;
      }
      return Json(response);
    }
  }
}
