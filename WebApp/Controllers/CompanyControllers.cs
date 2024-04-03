using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Responses;
using WebApp.Services;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/Company/")]
public class CompanyControllers(ICompanyService companyService): ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpGet]
    public Responses<List<Company>> GetCompanies()
    {
        return _companyService.GetCompanies();
    }

    [HttpGet("{companyid:int}")]
    public Responses<Company> GetCompanyById(int companyid)
    {
        return _companyService.GetCompanyById(companyid);
    }

    [HttpPost]
    public Responses<string> AddCompany(Company company)
    {
        return _companyService.AddCompany(company);
    }

    [HttpPut]
    public Responses<string> UpdateCompany(Company company)
    {
        return _companyService.UpdatedCompany(company);
    }

    [HttpDelete("{companyid:int}")]
    public Responses<bool> DeleteCompany(int companyid)
    {
        return _companyService.DeleteCompany(companyid);
    }
}
