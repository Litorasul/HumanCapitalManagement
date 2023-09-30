using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesManagingAPI.Models;
public class Department
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Department Name is required.")]
    public string Name { get; set; }
    [ForeignKey("Employee")]
    public int? DepartmentManagerId { get; set; }
    public Employee DepartmentManager { get; set; }
}
