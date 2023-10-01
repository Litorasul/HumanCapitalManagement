using DataAnalysisAPI.DTOs.ExportDTOs;
using Newtonsoft.Json;

namespace DataAnalysisAPI.Services.DataAccess;
public class EmployeeApiDataAccessService : IEmployeeApiDataAccessService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeApiDataAccessService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<EmployeeExportDTO>> GetAllEmployees()
    {
        var path = "https://localhost:44302/api/Employees/all";
        var client = _httpClientFactory.CreateClient();

        var result = new List<EmployeeExportDTO>();
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<EmployeeExportDTO>>(json);
        }

        return result;
    }

    public async Task<List<PositionExportDTO>> GetAllPositions()
    {
        var path = "https://localhost:44302/api/Positions/all";
        var client = _httpClientFactory.CreateClient();

        var result = new List<PositionExportDTO>();
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<PositionExportDTO>>(json);
        }

        return result;
    }
}
