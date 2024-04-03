using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public interface IDepartmentService
{
    Responses<List<Department>> GetDepartments();
    Responses<Department> GetDepartmentById(int id);
    Responses<string> AddDepartment(Department add);
    Responses<string> UpdateDepartment(Department upd);
    Responses<bool> DeleteDepartment(int id);
}
