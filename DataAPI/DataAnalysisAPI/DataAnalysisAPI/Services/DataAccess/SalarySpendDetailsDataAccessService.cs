using DataAnalysisAPI.Data;
using DataAnalysisAPI.DTOs.ExportDTOs;
using DataAnalysisAPI.DTOs.ImportDTOs;
using DataAnalysisAPI.Models;

namespace DataAnalysisAPI.Services.DataAccess;

public class SalarySpendDetailsDataAccessService
{
    private readonly DataAnalysisDbContext _context;

    public SalarySpendDetailsDataAccessService(DataAnalysisDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateSalarySpendDetais(SalarySpendDailyImportDTO dailyImportDTO)
    {
        if (dailyImportDTO.InsertedTime == null)
        {
            dailyImportDTO.InsertedTime = DateTime.Now;
        }
        var details = new SalarySpendDetailsDaily
        {
            InsertedTime = (DateTime)dailyImportDTO.InsertedTime,
            SmallestSalary = dailyImportDTO.SmallestSalary,
            DepartmentWithSmallestSalary = dailyImportDTO.DepartmentWithSmallestSalary,
            LargestSalary = dailyImportDTO.LargestSalary,
            DepartmentWithLargestSalary = dailyImportDTO.DepartmentWithLargestSalary
        };

        await _context.SalarySpendDetailsDailies.AddAsync(details);
        await _context.SaveChangesAsync();

        return details.Id;
    }

    public List<SalarySpendDailyExportDTO> GetAllSalarySpendDetailsForAPeriod(DateTime from, DateTime to)
    {
       var dailySpends = _context.SalarySpendDetailsDailies.Where(s => s.InsertedTime >= from &&  s.InsertedTime <= to).ToList();

        var result = new List<SalarySpendDailyExportDTO>();
        foreach ( var spend in dailySpends )
        {
            var dto = new SalarySpendDailyExportDTO
            {
                Id = spend.Id,
                InsertedTime = spend.InsertedTime,
                SmallestSalary = spend.SmallestSalary,
                DepartmentWithSmallestSalary = spend.DepartmentWithSmallestSalary,
                LargestSalary = spend.LargestSalary,
                DepartmentWithLargestSalary= spend.DepartmentWithLargestSalary
            };
            result.Add(dto);
        }
        return result;
    }
}
