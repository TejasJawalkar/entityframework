﻿using EntityFrameworkUse1._0._0.Data;
using EntityFrameworkUse1._0._0.module;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace EntityFrameworkUse1._0._0.Controllers
{
    public class EmployeeController : Controller
    {
        #region Object Declaration
        private readonly ApplicationContext _context;
        #endregion

        #region Object Assigning
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }
        #endregion

        #region Use of Get
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
#endregion

        #region Use of Post
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

        [HttpPost]
        [Route("Manager/AddProject")]
        public IActionResult AddProjects([FromForm] string ProjectName)
        {
            try
            {
                if (string.IsNullOrEmpty(ProjectName))
                {
                    return BadRequest(new { message = "Project Name Required" });
                }
                var project = new Projects
                {
                    PrjectName = ProjectName
                };
                _context.Projects.Add(project);
                _context.SaveChanges();
                return Ok(new { message = "Project Added" });
            }
            catch (Exception)
            {
                return StatusCode(500,new {message="Internal Server Error"});
            }
        }

        [HttpPost]
        [Route("Manager/AssignProjectToEmployee")]
        public IActionResult AssignProjectToEmployee([FromForm] Int64 E_Id, [FromForm] Int64 Project_Id )
        {
            try
            {
                if ((E_Id == 0) || (Project_Id == 0))
                {
                    return BadRequest(new { message = "Select Project Or Eployee" });
                }
                var employeeProject = new EmployeeProject
                {
                    E_Id = E_Id,
                    Projects_Id = Project_Id,
                };
                _context.EmployeeProjects.Add(employeeProject);
                _context.SaveChanges();
                return Ok( new {message="Project Assigne to employee" });
            }
            catch (Exception)
            {
                return StatusCode(500,new { message="Internal Server Error"});
            }
        }
        #endregion

        #region Use of Put
        [HttpPut]
        [Route("Hr/EmployeeUpdate")]
        public IActionResult UpdateEmployee ([FromForm] Int64 E_Id, [FromForm] Int64 M_Id, [FromForm] String E_F_Name, [FromForm] String E_L_Name, [FromForm] Double Salary, [FromForm] String E_Address, [FromForm] string E_MobileNo, [FromForm] string E_Email)
        {
            try
            {
                if ((E_Id==0) || (M_Id == 0) || String.IsNullOrEmpty(E_F_Name.Trim()) || String.IsNullOrEmpty(E_L_Name.Trim()) || (Salary == 0))
                {
                    return BadRequest(new { message = "All Fields are required" });
                }
                var employee = _context.Employees.FirstOrDefault(e=>e.E_Id==E_Id);
                if(employee==null)
                {
                    return StatusCode(404,new { message = "Employee Following Id Not Found" });
                }
                var existing1 = _context.Employees.Where(s=>s.E_Id==E_Id).FirstOrDefault<Employee>();
                var existing2 = _context.EployeeDetails.Where(s => s.E_Id == E_Id).FirstOrDefault<EployeeDetails>();

                if (existing1 != null) 
                {
                    existing1.E_F_Name = E_F_Name;
                    existing1.E_L_Name = E_L_Name;
                    existing1.Salary = Salary;
                    existing1.M_Id = M_Id;
                }
                
                if (existing2 != null) 
                {
                    existing2.Email = E_Email;
                    existing2.MobileNo = E_MobileNo;
                    existing2.Address = E_Address;
                }
                _context.SaveChanges();

                return Ok(new { message = "Employee Updated" });
            }
            catch (Exception)
            {
                return StatusCode(500, new {message="Internal Server Error" });
            }
        }

        [HttpPut]
        [Route("Hr/ManagerUpdate")]
        public IActionResult UpdateManager([FromForm] Int64 M_Id, [FromForm] String M_F_Name, [FromForm] String M_L_Name, [FromForm] string Address)
        {
            try
            {
                if ( (M_Id == 0) || String.IsNullOrEmpty(M_F_Name.Trim()) || String.IsNullOrEmpty(M_L_Name.Trim()) || String.IsNullOrEmpty(Address.Trim()))
                {
                    return BadRequest(new { message = "All Fields are required" });
                }
                var existing = _context.Managers.Where(m => m.M_Id == M_Id).FirstOrDefault<Manager>();
                if(existing!=null)
                {
                    existing.M_F_Name = M_F_Name;
                    existing.M_L_Name = M_L_Name;
                    existing.M_Address = Address;
                    _context.SaveChanges();
                    return Ok(new {message="Manager Updated"});
                }
                else
                {
                    return StatusCode(404, new { message = "Manager With Id Not Found" });
                }
            }
            catch (Exception)
            {
               return StatusCode(500,new{ message="Internal Server Error"});
            }
        }


        [HttpPut]
        [Route("Manager/UpdateEmployeeProject")]
        public IActionResult UpdateEmployeeProject([FromForm] Int64 E_Id, [FromForm] Int64 M_Id)
        {
            try
            {
                if ((E_Id==0)||(M_Id==0))
                {
                    return BadRequest(new {message="All Fields are Required" });
                }
                var data = _context.EmployeeProjects.Where(e => e.E_Id == E_Id).FirstOrDefault<EmployeeProject>();
                if(data!=null)
                {
                    data.Projects_Id = M_Id;
                    _context.SaveChanges();
                    return Ok(new { message = "Employee assigned to the Project" });
                }
                else
                {
                    return StatusCode(404,new { message="Employee not found to assign the Project"});
                }
            }
            catch (Exception)
            {
                return StatusCode(500,new { message="Internal Server Error"});
            }
        }

        #endregion

        #region Use of Delete
        #endregion
    }
}
