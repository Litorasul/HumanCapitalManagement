using DataAnalysisAPI.DTOs.ImportDTOs;

namespace DataAnalysisAPI.Services.BusinessLogic
{
    public interface IDailySalaryAnalysisBuisnessLogicService
    {
        Task<SalarySpendDailyImportDTO> AnalyzeSalaryData();
    }
}