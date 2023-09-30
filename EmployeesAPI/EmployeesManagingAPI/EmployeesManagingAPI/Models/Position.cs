using System.ComponentModel.DataAnnotations;

namespace EmployeesManagingAPI.Models;

public class Position
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Position Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Minimum Salary fo this possition is required.")]
    public decimal MinSalary { get; set; }
    [Required(ErrorMessage = "Maximum Salary fo this possition is required.")]
    public decimal MaxSalary { get; set; }
}
