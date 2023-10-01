namespace DataAnalysisAPI.DTOs.ImportDTOs;
public class SalarySpendDailyImportDTO
{
    public DateTime? InsertedTime { get; set; }

    public decimal SmallestSalary { get; set; }
    public string? DepartmentWithSmallestSalary { get; set; }
    public decimal LargestSalary { get; set; }
    public string? DepartmentWithLargestSalary { get; set; }
    public decimal TotalSpend { get; set; }
}
