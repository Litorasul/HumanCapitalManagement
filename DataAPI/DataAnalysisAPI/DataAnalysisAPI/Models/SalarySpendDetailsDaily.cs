using System.ComponentModel.DataAnnotations;

namespace DataAnalysisAPI.Models;

public class SalarySpendDetailsDaily
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "InsertedTime is required.")]
    public DateTime InsertedTime { get; set; }

    public decimal SmallestSalary { get; set; }
    public string DepartmentWithSmallestSalary { get; set; }
    public decimal LargestSalary { get; set; }
    public string DepartmentWithLargestSalary { get; set; }
    public decimal TotalSpend { get; set; }

}
