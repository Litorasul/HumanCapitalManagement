using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeesManagingAPI.Models;
public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Employee Name is required.")]
    public string Name { get; set; }
    public string? Email { get; set; }
    [Required(ErrorMessage = "Salary is required.")]
    public decimal Salary { get; set; }
    [ForeignKey("Position")]
    public int PositionId { get; set; }
    public Position Position { get; set; }
    [ForeignKey("Employee")]
    public int? ManagerId { get; set; }
    public Employee Manager { get; set; }
}
