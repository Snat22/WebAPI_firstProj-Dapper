using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Responses;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/Employees/")]
public class EmployeeControllers(IEmployeeService employeeService):ControllerBase
{
    private readonly IEmployeeService _employeeService1 = employeeService;
    [HttpGet]
    public Responses<List<Employee>> GetEmployees()
    {
        return _employeeService1.GetEmployee();
    }

    [HttpGet("{employeeid:int}")]
    public Responses<Employee> GetEmployeeById(int employeeid)
    {
        return _employeeService1.GetEmployeeById(employeeid);
    }

    [HttpPost]
    public Responses<string>Add(Employee employee)
    {
        return _employeeService1.AddEmployee(employee);
    }

    [HttpPut]
    public Responses<string> Update(Employee employee)
    {
        return _employeeService1.UpdateEmployee(employee);
    }

    [HttpDelete("{employeeid:int}")]
    public Responses<bool> Delete(int employeeid)
    {
        return _employeeService1.DeleteEmployee(employeeid);
    }

}
