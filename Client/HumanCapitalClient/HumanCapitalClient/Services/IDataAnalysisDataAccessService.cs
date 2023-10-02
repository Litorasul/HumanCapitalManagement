using HumanCapitalClient.DTOs;

namespace HumanCapitalClient.Services
{
    public interface IDataAnalysisDataAccessService
    {
        Task<List<SalarySpendDailyExportDTO>> GetSalarySpendDataForPeriod(DateTime from, DateTime to);
    }
}