using HumanCapitalClient.DTOs;
using Newtonsoft.Json;

namespace HumanCapitalClient.Services;
public class EmployeesDataAccessService : IEmployeesDataAccessService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeesDataAccessService(IHttpClientFactory httpClientFactory)
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

    public async Task<EmployeeExportDTO> GetEmployeeByName(string name)
    {
        var path = $"https://localhost:44302/api/Employees/search?name={name}";
        var client = _httpClientFactory.CreateClient();

        var result = new EmployeeExportDTO();
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<EmployeeExportDTO>(json);
        }

        return result;
    }

    public async Task CreateEmployee(EmployeeImportDTO employeeImport)
    {
        var path = "https://localhost:44302/api/Employees/create";
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync(path, employeeImport);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateEmployee(int id, EmployeeImportDTO employeeImport)
    {
        var path = $"https://localhost:44302/api/Employees/update&id={id}";
        var client = _httpClientFactory.CreateClient();
        var response = await client.PutAsJsonAsync(path, employeeImport);
        response.EnsureSuccessStatusCode();
    }
}
