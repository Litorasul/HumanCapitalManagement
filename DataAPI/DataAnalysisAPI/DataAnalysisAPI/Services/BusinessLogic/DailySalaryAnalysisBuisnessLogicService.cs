using DataAnalysisAPI.DTOs.ImportDTOs;
using DataAnalysisAPI.Services.DataAccess;

namespace DataAnalysisAPI.Services.BusinessLogic;

public class DailySalaryAnalysisBuisnessLogicService : IDailySalaryAnalysisBuisnessLogicService
{
    private readonly IEmployeeApiDataAccessService _employeeApiDataAccessService;

    public DailySalaryAnalysisBuisnessLogicService(IEmployeeApiDataAccessService employeeApiDataAccessService)
    {
        _employeeApiDataAccessService = employeeApiDataAccessService;
    }

    public async Task<SalarySpendDailyImportDTO> AnalyzeSalaryData()
    {
        var employees = await _employeeApiDataAccessService.GetAllEmployees();

        var personWithSmallestSalary = employees.Where((x) => x.Salary == employees.Min(y => y.Salary)).FirstOrDefault();
        var personWithLargestSalary = employees.Where((x) => x.Salary == employees.Max(y => y.Salary)).FirstOrDefault();
        var total = employees.Sum(x => x.Salary);

        return new SalarySpendDailyImportDTO
        {
            InsertedTime = DateTime.Now,
            SmallestSalary = personWithSmallestSalary.Salary,
            LargestSalary = personWithLargestSalary.Salary,
            TotalSpend = total
        };
    }
}
