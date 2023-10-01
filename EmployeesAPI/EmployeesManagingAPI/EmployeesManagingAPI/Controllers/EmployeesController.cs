using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Services.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagingAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeDataAccessService _employeeDataAccessService;

    public EmployeesController(IEmployeeDataAccessService employeeDataAccessService)
    {
        _employeeDataAccessService = employeeDataAccessService;
    }

    //GET ..api/employees/search?name=foo 
    [HttpGet("search")]
    public ActionResult<EmployeeExportDTO> GetEmployeeByName(string name)
    {
        try
        {
            var employee = _employeeDataAccessService.GetEmployeeByName(name);
            return Ok(employee);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }


    //GET ..api/employees/all 
    [HttpGet("all")]
    public ActionResult<List<EmployeeExportDTO>> GetAllEmployees()
    {
        try
        {
            var employees = _employeeDataAccessService.GetAllEmployees();
            return Ok(employees);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //GET ..api/employees/manager?managerId=1
    [HttpGet("manager")]
    public ActionResult<List<EmployeeExportDTO>> GetAllEmployeesForManager(int managerId)
    {
        try
        {
            var employees = _employeeDataAccessService.GetAllEmployeesForAManager(managerId);
            return Ok(employees);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //GET ..api/employees/position?positionId=1
    [HttpGet("position")]
    public ActionResult<List<EmployeeExportDTO>> GetAllEmployeesForPosition(int positionId)
    {
        try
        {
            var employees = _employeeDataAccessService.GetAllEmployeesOnAPosition(positionId);
            return Ok(employees);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Post ..api/employees/create
    [HttpPost("create")]
    public async Task<ActionResult<int>> CreateEmployee([FromBody] EmployeeImportDTO employee)
    {
        if (employee == null) { return BadRequest(); }

        var employeeId = await _employeeDataAccessService.CreateEmployee(employee);

        return Ok(employeeId);
    }

    //Put ..api/employees/manager?employeeId=1&managerId=1
    [HttpPut("manager")]
    public async Task<IActionResult> AddOrUpdateManager(int employee, int managerId)
    {
        try
        {
            await _employeeDataAccessService.AddOrUpdateManagerToEmployee(employee, managerId);
            return Ok();
        }
        catch (NullReferenceException ex)
        {

            return NotFound(ex.Message);
        }
    }

    //Put ..api/employees/position?employeeId=1&positionId=1
    [HttpPut("position")]
    public async Task<IActionResult> AddOrUpdatePosition(int employeeId, int positionId)
    {
        try
        {
            await _employeeDataAccessService.AddOrUpdatePositionToEmployee(employeeId, positionId);
            return Ok();
        }
        catch (NullReferenceException ex)
        {

            return NotFound(ex.Message);
        }
    }

    //Put ..api/employees/update&id=1
    [HttpPut("update")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeImportDTO newEmployeeInfo)
    {
        if (newEmployeeInfo == null)
        {
            return BadRequest();
        }

        try
        {
            await _employeeDataAccessService.UpdateEmployee(id, newEmployeeInfo);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Delete ..api/employees/delete&id=1
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _employeeDataAccessService.DeleteEmployee(id);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
