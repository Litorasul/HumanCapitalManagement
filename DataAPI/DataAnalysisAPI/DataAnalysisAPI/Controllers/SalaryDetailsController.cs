using DataAnalysisAPI.DTOs.ExportDTOs;
using DataAnalysisAPI.Services.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace DataAnalysisAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SalaryDetailsController : ControllerBase
{
    private readonly ISalarySpendDetailsDataAccessService _dataAccessService;

    public SalaryDetailsController(ISalarySpendDetailsDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    //GET ..api/SalaryDetails/search?name=foo 
    [HttpGet]
    public ActionResult<List<SalarySpendDailyExportDTO>> GetSalaryDetailsForAPeriod(DateTime from, DateTime to)
    {
        try
        {
            var salarySpends = _dataAccessService.GetAllSalarySpendDetailsForAPeriod(from, to);
            return Ok(salarySpends);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
