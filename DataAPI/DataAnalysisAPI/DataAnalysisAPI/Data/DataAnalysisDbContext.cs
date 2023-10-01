using DataAnalysisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAnalysisAPI.Data;
public class DataAnalysisDbContext : DbContext
{
    public DataAnalysisDbContext(DbContextOptions options) : base(options)
    {    }

    public DbSet<SalarySpendDetailsDaily> SalarySpendDetailsDailies { get; set; }
}
