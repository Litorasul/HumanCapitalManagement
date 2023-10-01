namespace EmployeesManagingAPI.DTOs.ExportDTOs;
public class DepartmentExportDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int? DepartmentManagerId { get; set; }
}
