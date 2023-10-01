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


}
