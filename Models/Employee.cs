using System.ComponentModel.DataAnnotations;

namespace Employee_EF.Models;

public class Employee
{
    [Key]
    public int E_No { get; set; }
    public required string EmployeeName { get; set; }
    public required string Email { get; set; }
    public required string phone { get; set; }
}