using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;

namespace EmployeesManagingAPI.Services.DataAccess
{
    public interface IDepartmentDataAccessService
    {
        Task AddOrUpdateManagerToDepartment(int id, int managerId);
        Task<int> CreateDepartment(DepartmentImportDTO dto);
        Task DeletePosition(int id);
        DepartmentExportDTO GetDepartmentById(int id);
        DepartmentExportDTO GetDepartmentByName(string name);
        Task UpdateDepartment(int id, DepartmentImportDTO dto);
    }
}