namespace WebApp.Models;

public class Company
{
    public int Id { get; set; }
    public required string Name  { get; set; }
    public int Department_Id { get; set; }
    public string Address { get; set; }
}
