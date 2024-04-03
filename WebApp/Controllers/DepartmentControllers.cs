using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Responses;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/Department/")]
public class DepartmentControllers(IDepartmentService departmentService):ControllerBase
{
    private readonly IDepartmentService _departmentService1 = departmentService;

    [HttpGet]
    public Responses<List<Department>> GetDepartments()
    {
        return _departmentService1.GetDepartments();
    }

    [HttpGet("{departmentid:int}")]
    public Responses<Department> GetDepartmentById(int departmentid)
    {
        return _departmentService1.GetDepartmentById(departmentid);
    }

    [HttpPost]
    public Responses<string> Add(Department department)
    {
        return _departmentService1.AddDepartment(department);
    }

    [HttpPut]
    public Responses<string>Update(Department department)
    {
        return _departmentService1.UpdateDepartment(department);
    }

    [HttpDelete("{department_id:int}")]
    public Responses<bool> Delete(int department_id)
    {
            return _departmentService1.DeleteDepartment(department_id);
    }

}
