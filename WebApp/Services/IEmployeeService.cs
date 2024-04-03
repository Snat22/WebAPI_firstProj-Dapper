using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public interface IEmployeeService
{
    Responses<List<Employee>> GetEmployee();
    Responses<Employee> GetEmployeeById(int id);
    Responses<string> AddEmployee(Employee add);
    Responses<string> UpdateEmployee(Employee upd);
    Responses<bool> DeleteEmployee(int id);
}
