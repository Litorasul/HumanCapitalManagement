using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;

namespace EmployeesManagingAPI.Services.DataAccess
{
    public interface IEmployeeDataAccessService
    {
        Task AddOrUpdateManagerToEmployee(int id, int managerId);
        Task AddOrUpdatePositionToEmployee(int id, int positionId);
        Task<int> CreateEmployee(EmployeeImportDTO employeeImportDTO);
        Task DeleteEmployee(int id);
        List<EmployeeExportDTO> GetAllEmployeesForAManager(int managerId);
        List<EmployeeExportDTO> GetAllEmployeesOnAPosition(int positionId);
        EmployeeExportDTO GetEmployeeById(int id);
        Task UpdateEmployee(int id, EmployeeImportDTO employeeImportDTO);

        EmployeeExportDTO GetEmployeeByName(string name);
        List<EmployeeExportDTO> GetAllEmployees();
    }
}