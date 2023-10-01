using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Services.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly IPositionDataAccessService _positionDataAccessService;

    public PositionsController(IPositionDataAccessService positionDataAccessService)
    {
        _positionDataAccessService = positionDataAccessService;
    }

    //GET ..api/positions/search?name=foo 
    [HttpGet("search")]
    public ActionResult<PositionExportDTO> GetPositionByName(string name)
    {
        try
        {
            var position = _positionDataAccessService.GetPositionByName(name);
            return Ok(position);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Post ..api/positions/create
    [HttpPost("create")]
    public async Task<ActionResult<int>> CreatePosition([FromBody] PositionImportDTO position)
    {
        if (position == null) { return BadRequest(); }

        var positionId = await _positionDataAccessService.CreatePosition(position);

        return Ok(positionId);
    }

    //Put ..api/positions/update&id=1
    [HttpPut("update")]
    public async Task<IActionResult> UpdatePosition(int id, [FromBody] PositionImportDTO newPositionInfo)
    {
        if (newPositionInfo == null)
        {
            return BadRequest();
        }

        try
        {
            await _positionDataAccessService.UpdatePosition(id, newPositionInfo);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    //Delete ..api/positions/delete&id=1
    [HttpDelete("delete")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        try
        {
            await _positionDataAccessService.DeletePosition(id);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
