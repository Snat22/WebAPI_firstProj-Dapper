using WebApp.Models;
using WebApp.Responses;

namespace WebApp.Services;

public interface ICompanyService
{
    Responses<List<Company>> GetCompanies();
    Responses<Company> GetCompanyById(int id);
    Responses<string> AddCompany(Company add);
    Responses<string> UpdatedCompany(Company upd);
    Responses<bool> DeleteCompany(int id);
    }
