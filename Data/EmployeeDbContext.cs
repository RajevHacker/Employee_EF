using Employee_EF.Models;
using Microsoft.EntityFrameworkCore;
namespace Employee_EF.Data;

public class EmployeeDbContext:DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

}