using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;

namespace EmployeesManagingAPI.Services.DataAccess
{
    public interface IPositionDataAccessService
    {
        Task<int> CreatePosition(PositionImportDTO positionDTO);
        Task DeletePosition(int id);
        PositionExportDTO GetPositionById(int id);
        PositionExportDTO GetPositionByName(string name);
        Task UpdatePosition(int id, PositionImportDTO positionDTO);
    }
}