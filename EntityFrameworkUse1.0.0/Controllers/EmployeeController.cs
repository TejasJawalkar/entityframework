using EntityFrameworkUse1._0._0.Data;
using EntityFrameworkUse1._0._0.module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace EntityFrameworkUse1._0._0.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Employees")]
        public IActionResult GetEmployees()
        {
            var employees = (from e in _context.Employees
                             join ed in _context.EployeeDetails
                             on e.E_Id equals ed.E_Id
                             join m in _context.Managers 
                             on e.M_Id equals m.M_Id
                             select new
                             {
                                 e.E_Id,
                                 e.E_F_Name,
                                 e.E_L_Name,
                                 e.Salary,
                                 ed.Email,
                                 ed.MobileNo,
                                 ed.Address,
                                 m.M_F_Name,
                                 m.M_L_Name
                             }).ToList();
            return Json(employees);
        }

        [HttpGet]
        [Route("Employee")]
        public IActionResult GetEmployee(Int64 id)
        {
            Console.WriteLine(id);
            var data=(from e in _context.Employees
                            join ed in _context.EployeeDetails
                            on e.E_Id equals ed.E_Id
                            join m in _context.Managers
                            on e.M_Id equals m.M_Id
                            where e.E_Id == id
                            select new
                            {
                                e.E_Id,
                                e.E_F_Name,
                                e.E_L_Name,
                                e.Salary,
                                ed.Email,
                                ed.MobileNo,
                                ed.Address,
                                m.M_F_Name,
                                m.M_L_Name
                            }).ToList();
                return Json(data);
        }

        [HttpGet]
        [Route("Managers")]
        public IActionResult GetManagers()
        {
            var Managers = (from m in _context.Managers
                            select new
                            { 
                               m.M_Id,
                               m.M_F_Name,
                               m.M_L_Name,
                               m.M_Address
                            }).ToList();
            return Json(Managers);
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult GetProjects()
        {
            var Projects =(from p in _context.Projects
                           select new
                           {
                               p.Project_Id,
                               p.PrjectName
                           }).ToList();
            return Json(Projects);
        }

        [HttpGet]
        [Route("EmployeeProjects")]
        public IActionResult GetProjectAssignedtoEmployee()
        {
            var data = (from ep in _context.EmployeeProjects
                        join e in _context.Employees
                        on ep.E_Id equals e.E_Id
                        join p in _context.Projects
                        on ep.Projects_Id equals p.Project_Id
                        select new
                        {
                            e.E_Id,
                            e.E_F_Name,
                            e.E_L_Name,
                            p.Project_Id,
                            p.PrjectName
                        }).ToList();
            return Json(data);
        }

        [HttpPost]
        [Route("HR/AddManager")]
        public IActionResult AddManager([FromForm] String M_F_Name, [FromForm] String M_L_Name,[FromForm] String M_Address)
        {
            try
            {
                if (String.IsNullOrEmpty(M_F_Name.Trim()) || String.IsNullOrEmpty(M_L_Name.Trim()) || String.IsNullOrEmpty(M_Address.Trim())) 
                {
                    return BadRequest(new {message="All Fields are required"});
                }
                var manager = new Manager {
                    M_F_Name = M_F_Name.Trim(),
                    M_L_Name = M_L_Name.Trim(),
                    M_Address = M_Address.Trim(),
                };
                _context.Managers.Add(manager);
                _context.SaveChanges();
                
                return Ok(new {message="Manager Added"});
            }
            catch (Exception ex)
            {
                return StatusCode(500,new {message="Internal Server Error"});
            }
        }

        [HttpPost]
        [Route("HR/AddEmployee")]
        public IActionResult AddEmployee([FromForm] Int64 M_Id,[FromForm] String E_F_Name, [FromForm] String E_L_Name, [FromForm] Double Salary, [FromForm] String E_Address, [FromForm] string E_MobileNo, [FromForm] string E_Email)
        {
            try
            {
                if ((M_Id==0)|| String.IsNullOrEmpty(E_F_Name.Trim()) || String.IsNullOrEmpty(E_L_Name.Trim()) || (Salary==0))
                {
                    return BadRequest(new { message = "All Fields are required" });
                }
                var employee = new Employee
                {
                    M_Id=M_Id,
                    E_F_Name=E_F_Name.Trim(),
                    E_L_Name=E_L_Name.Trim(),
                    Salary=Salary,
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                var employeeDetails = new EployeeDetails
                {
                    E_Id=employee.E_Id,
                    MobileNo=E_MobileNo.Trim(),
                    Address=E_Address.Trim(),
                    Email=E_Email.Trim(),
                };
                _context.EployeeDetails.Add(employeeDetails);
                _context.SaveChanges();

                return Ok(new { message = "Employee Added" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }
    }
}
