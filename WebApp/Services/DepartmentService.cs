using System.Net;
using Dapper;
using WebApp.DataContext;
using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public class DepartmentService : IDepartmentService
{
    private readonly DapperContext _context;
    public DepartmentService(DapperContext context)
    {
        _context = context;
    }
    public Responses<string> AddDepartment(Department add)
    {
        try
        {
            var sql = @$"insert into departments(name,employee_id)
            values('{add.Name}',{add.Employee_Id})";
            var inserted = _context.Connection().Execute(sql);
            if(inserted > 0) return new Responses<string>("Added Succesfully");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public Responses<Department> GetDepartmentById(int id)
    {

        try
        {
            var sql = @$"select * from departments where id={@id}";
            var selected = _context.Connection().QueryFirstOrDefault<Department>(sql);
            if(selected!= null) return new Responses<Department>(selected);
            return new Responses<Department>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new Responses<Department>(HttpStatusCode.InternalServerError,e.Message);
        }  
          }

    public Responses<List<Department>> GetDepartments()
    {
try
        {
            var sql = @$"select * from departments";
            var selected = _context.Connection().Query<Department>(sql).ToList();
             return new Responses<List<Department>>(selected);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new Responses<List<Department>>(HttpStatusCode.InternalServerError,e.Message);
        }    }

    public Responses<string> UpdateDepartment(Department upd)
    {
        try
        {
            var sql = @$"update departments set name='{upd.Name}',employee_id={upd.Employee_Id} where id = {upd.Id}";
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

        public Responses<bool> DeleteDepartment(int id)
    {
try
        {
            var sql = @$"delete from departments where id={@id}";
            var deleted = _context.Connection().Execute(sql);
            if(deleted> 0) return new Responses<bool>(true);
            return new Responses<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }    }


}
