namespace EmployeesManagingAPI.DTOs.ImoportDTOs;
public class EmployeeImpotrDTO
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public decimal Salary { get; set; }
    public int PositionId { get; set; }
    public int? ManagerId { get; set; }
}
