using DataAnalysisAPI.Services.BusinessLogic;
using DataAnalysisAPI.Services.DataAccess;

namespace DataAnalysisAPI.Services;

public class DailyJobService : BackgroundService
{
    private readonly PeriodicTimer _periodicTimer = new PeriodicTimer(TimeSpan.FromDays(1));
    private readonly IServiceProvider _serviceProvider;
    public DailyJobService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _periodicTimer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var salaryAnalysisBL = scope.ServiceProvider.GetRequiredService<IDailySalaryAnalysisBuisnessLogicService>();
                var salarySpendDAL = scope.ServiceProvider.GetRequiredService<ISalarySpendDetailsDataAccessService>();

                var dataForAdding = await salaryAnalysisBL.AnalyzeSalaryData();
                await salarySpendDAL.CreateSalarySpendDetais(dataForAdding);
            }
        }
    }
}
