using DataAnalysisAPI.DTOs.ExportDTOs;
using DataAnalysisAPI.DTOs.ImportDTOs;

namespace DataAnalysisAPI.Services.DataAccess
{
    public interface ISalarySpendDetailsDataAccessService
    {
        Task<int> CreateSalarySpendDetais(SalarySpendDailyImportDTO dailyImportDTO);
        List<SalarySpendDailyExportDTO> GetAllSalarySpendDetailsForAPeriod(DateTime from, DateTime to);
    }
}