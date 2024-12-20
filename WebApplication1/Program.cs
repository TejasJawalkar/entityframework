using WebApplication1.data;
using WebApplication1.module;

#region Connectivity
using (var context=new Context())
{

  #region Module Object Creation
  var manager = new Manager();
  var employe = new Employee();
  var empDetails = new EployeeDetails();
  var project = new Projects();
  var eproject = new EmployeeProject();
  #endregion

  #region CRUD Operations
  #region Get All Employee
  //var employeesdata = context.Employees.ToList();
  //Console.WriteLine("get all data");
  //foreach (var item in employeesdata)
  //{
  //  Console.WriteLine($"Employee Name= {item.E_F_Name.ToString() + ' ' + item.E_L_Name.ToString()} Salary= {item.Salary.ToString("F2")}");
  //}
  #endregion

  #region Get Single Employee
  //var employeedata = context.Employees.Single(e => e.E_Id == 1);
  //Console.WriteLine("\nGet Signle Data");
  //Console.WriteLine($"Employee Name= {employeedata.E_F_Name.ToString() + ' ' + employeedata.E_L_Name.ToString()} Salary= {employeedata.Salary.ToString("F2")}");
  #endregion

  #region Update Employee
  //var employeedata = context.Employees.Single(e => e.E_Id == 2);
  //employeedata.E_F_Name = "Geralt";
  //Console.WriteLine("\nBefore Update\n");
  //Console.WriteLine($"Employee ID= {employeedata.E_Id} Employee Name= {employeedata.E_F_Name.ToString() + ' ' + employeedata.E_L_Name.ToString()} Salary= {employeedata.Salary.ToString("F2")}");
  //context.SaveChanges();
  //Console.WriteLine("\nAfter Update\n");
  //Console.WriteLine($"Employee ID= {employeedata.E_Id} Employee Name= {employeedata.E_F_Name.ToString() + ' ' + employeedata.E_L_Name.ToString()} Salary= {employeedata.Salary.ToString("F2")}");
  #endregion

  #region Delete Employee
  var delemployeedata = context.Employees.Single(e => e.E_Id == 1);
  context.Employees.Remove(delemployeedata);
  context.SaveChanges();
  #endregion
  #endregion

  #region Adding Data Into Database using Modules
  //manager.M_F_Name = "Richard";
  //manager.M_L_Name = "Lawson";
  //manager.M_Address = "Los Anglis, USA";
  //context.Managers.Add(manager);
  //context.SaveChanges();

  //employe.E_F_Name = "Geralt";
  //employe.E_L_Name = "Sharma";
  //employe.Salary = 10000.50;
  //employe.M_Id = 1;
  //context.Employees.Add(employe);
  //context.SaveChanges();

  //empDetails.Address = "Maharashtra, India";
  //empDetails.MobileNo = "9172804246";
  //empDetails.Email = "Geralt.Sharma@gmail.com";
  //empDetails.E_Id = 2;
  //context.EployeeDetails.Add(empDetails);
  //context.SaveChanges();


  //project.PrjectName = "ERP System";
  //context.Projects.Add(project);
  //context.SaveChanges();

  //eproject.E_Id = 2;
  //eproject.Projects_Id = 1;
  //context.EmployeeProjects.Add(eproject);
  //context.SaveChanges();
  #endregion

  Console.WriteLine("Press Any Key to Exit...");
  Console.ReadKey();
}
#endregion
