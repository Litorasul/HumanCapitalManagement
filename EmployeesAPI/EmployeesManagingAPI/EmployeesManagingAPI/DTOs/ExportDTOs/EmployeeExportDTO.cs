﻿namespace EmployeesManagingAPI.DTOs.ExportDTOs;

public class EmployeeExportDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public decimal Salary { get; set; }
    public int PositionId { get; set; }
    public int? ManagerId { get; set; }
}
