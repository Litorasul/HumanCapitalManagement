using DataAnalysisAPI.Services.BusinessLogic;
using DataAnalysisAPI.Services.DataAccess;

namespace DataAnalysisAPI.Services;

public class DailyJobService : BackgroundService
{
    private readonly PeriodicTimer _periodicTimer = new PeriodicTimer(TimeSpan.FromDays(1));
    private readonly IDailySalaryAnalysisBuisnessLogicService _analysisBuisnessLogicService;
    private readonly ISalarySpendDetailsDataAccessService _salarySpendDetailsDataAccessService;

    public DailyJobService(IDailySalaryAnalysisBuisnessLogicService analysisBuisnessLogicService, ISalarySpendDetailsDataAccessService salarySpendDetailsDataAccessService)
    {
        _analysisBuisnessLogicService = analysisBuisnessLogicService;
        _salarySpendDetailsDataAccessService = salarySpendDetailsDataAccessService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
           var dataForAdding = await _analysisBuisnessLogicService.AnalyzeSalaryData();
           await _salarySpendDetailsDataAccessService.CreateSalarySpendDetais(dataForAdding);
        }
    }
}
