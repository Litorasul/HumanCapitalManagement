using DataAnalysisAPI.DTOs.ExportDTOs;

namespace DataAnalysisAPI.Services.DataAccess
{
    public interface IEmployeeApiDataAccessService
    {
        Task<List<EmployeeExportDTO>> GetAllEmployees();
        Task<List<PositionExportDTO>> GetAllPositions();
    }
}