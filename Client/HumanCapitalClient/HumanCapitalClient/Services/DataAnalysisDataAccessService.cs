using HumanCapitalClient.DTOs;
using Newtonsoft.Json;

namespace HumanCapitalClient.Services;
public class DataAnalysisDataAccessService : IDataAnalysisDataAccessService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DataAnalysisDataAccessService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<SalarySpendDailyExportDTO>> GetSalarySpendDataForPeriod(DateTime from, DateTime to)
    {
        var fromFormated = from.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK");
        var toFormated = to.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK");
        var path = $"https://localhost:44307/api/SalaryDetails?from={fromFormated}&to={toFormated}";
        var client = _httpClientFactory.CreateClient();

        var result = new List<SalarySpendDailyExportDTO>();
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<SalarySpendDailyExportDTO>>(json);
        }

        return result;
    }
}
