using System.Net;
using Dapper;
using WebApp.DataContext;
using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public class CompanyService : ICompanyService
{
       private readonly DapperContext _context;

    public CompanyService(DapperContext context)
    {
        _context = context;
    }
    public Responses<string> AddCompany(Company add)
    {
        try
        {
           
        var sql = @$"insert into companyes(name,address)
                valuse('{add.Name}','{add.Address}')";
                var inserted = _context.Connection().Execute(sql);
            if (inserted > 0) return new Responses<string>("Successfully created student");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error"); 
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public Responses<List<Company>> GetCompanies()
    {
        try
        {
            
        var sql = @$"select * from companyes";
        var selected = _context.Connection().Query<Company>(sql).ToList();
        return new Responses<List<Company>>(selected);
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<List<Company>>(HttpStatusCode.InternalServerError,e.Message);
        }

    }

    public Responses<Company> GetCompanyById(int id)
    {
        try
        {
            
        var sql = @$"select * from companyes where id = {@id}";
        var selected = _context.Connection().QueryFirstOrDefault<Company>(sql);
            if(selected!=null) return new Responses<Company>(selected);
            return new Responses<Company>(HttpStatusCode.BadRequest,"Company not found");
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<Company>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public Responses<string> UpdatedCompany(Company upd)
    {
        try
        {
            
        var sql = @$"update companyes set name='{upd.Name},address='{upd.Address}' where id = {upd.Id}";
        var updated = _context.Connection().Execute(sql);
        if(updated > 0) return new Responses<string>("Succesfully updated");
        return new Responses<string>(HttpStatusCode.BadRequest,"Updated not completed");
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

        public Responses<bool> DeleteCompany(int id)
    {
                try
        {
            
        var sql = @$"delete from companyes where id = {@id}";
        var deleted = _context.Connection().Execute(sql);
        if(deleted > 0) return new Responses<bool>(true);
        return new Responses<bool>(HttpStatusCode.BadRequest,"Coudnt deleted",false);      
          }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }

        }


}
