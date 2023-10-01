using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Services.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagingAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private IDepartmentDataAccessService _dataAccessService;

    public DepartmentsController(IDepartmentDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    //GET ..api/department/id?id=1 
    [HttpGet("id")]
    public ActionResult<DepartmentExportDTO> GetDepartmentById(int id)
    {
        try
        {
            var department = _dataAccessService.GetDepartmentById(id);
            return Ok(department);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //GET ..api/department/search?name=foo 
    [HttpGet("search")]
    public ActionResult<DepartmentExportDTO> GetDepartmentByName(string name)
    {
        try
        {
            var department = _dataAccessService.GetDepartmentByName(name);
            return Ok(department);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Post ..api/department/create
    [HttpPost("create")]
    public async Task<ActionResult<int>> CreateDepartment([FromBody] DepartmentImportDTO department)
    {
        if (department == null) { return BadRequest(); }

        var departmentId = await _dataAccessService.CreateDepartment(department);

        return Ok(departmentId);
    }

    //Put ..api/departments/manager?departmentId=1&managerId=1
    [HttpPut("manager")]
    public async Task<IActionResult> AddOrUpdateManager(int departmentId, int managerId)
    {
        try
        {
            await _dataAccessService.AddOrUpdateManagerToDepartment(departmentId, managerId);
            return Ok();
        }
        catch (NullReferenceException ex)
        {

            return NotFound(ex.Message);
        }
    }

    //Put ..api/departments/update&id=1
    [HttpPut("update")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentImportDTO newDepartmentInfo)
    {
        if (newDepartmentInfo == null)
        {
            return BadRequest();
        }

        try
        {
            await _dataAccessService.UpdateDepartment(id, newDepartmentInfo);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Delete ..api/department/delete&id=1
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        try
        {
            await _dataAccessService.DeleteDepartment(id);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
