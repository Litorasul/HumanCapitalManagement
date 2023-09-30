using EmployeesManagingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagingAPI.Data;
public class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions options) : base(options)
    {   }
   

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Department> Departments { get; set; }
}
