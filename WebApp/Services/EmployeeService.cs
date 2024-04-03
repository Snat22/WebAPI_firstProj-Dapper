using System.Net;
using Dapper;
using WebApp.DataContext;
using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DapperContext _context;
    
    public EmployeeService(DapperContext context)
    {
        _context = context;
    }
    public Responses<string> AddEmployee(Employee add)
    {
        try
        {
            
        var sql = @$"insert into employees(fristname,lastname,age,phone,address,email)
                values('{add.FristName}','{add.LastName}',{add.Age},'{add.Phone}','{add.Address}','{add.Email}')";
                var inserted = _context.Connection().Execute(sql);
                if(inserted > 0) return new Responses<string>("Added succesfully");
                return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public Responses<List<Employee>> GetEmployee()
    {
        try
        {
            var sql = @$"select * from employees";
            var selected = _context.Connection().Query<Employee>(sql).ToList();
            return new Responses<List<Employee>>(selected);
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<List<Employee>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public Responses<Employee> GetEmployeeById(int id)
    {

        try
        {
            var sql = @$"select * from employees where id = {@id}";
            var selected = _context.Connection().QueryFirstOrDefault<Employee>(sql);
            if(selected != null) return new Responses<Employee>(selected);
            return new Responses<Employee>(HttpStatusCode.BadRequest,"Error");  
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<Employee>(HttpStatusCode.InternalServerError,e.Message);
        }    
        }

    public Responses<string> UpdateEmployee(Employee upd)
    {
        
        try
        {
            var sql = @$"update employees set fristname='{upd.FristName}',lastname='{upd.LastName}',age={upd.Age},phone='{upd.Phone}',address='{upd.Address}',email='{upd.Email}' where id= {upd.Id}";
            var updated = _context.Connection().Execute(sql);
            if(updated > 0) return new Responses<string>("Yet Updated");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    
    public Responses<bool> DeleteEmployee(int id)
    {

        try
        {
            var sql = @$"delete from employees where id={@id}";
            var deleted = _context.Connection().Execute(sql);
            if(deleted > 0) return new Responses<bool>(true);
            return new Responses<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }    
        }


}
