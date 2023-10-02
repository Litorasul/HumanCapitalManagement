using HumanCapitalClient.DTOs;

namespace HumanCapitalClient.Services
{
    public interface IEmployeesDataAccessService
    {
        Task CreateEmployee(EmployeeImportDTO employeeImport);
        Task<List<EmployeeExportDTO>> GetAllEmployees();
        Task<EmployeeExportDTO> GetEmployeeByName(string name);
        Task UpdateEmployee(int id, EmployeeImportDTO employeeImport);
    }
}