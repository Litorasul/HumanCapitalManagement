using EmployeesManagingAPI.Data;
using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Models;

namespace EmployeesManagingAPI.Services.DataAccess;
public class PositionDataAccessService : IPositionDataAccessService
{
    private readonly EmployeesDbContext _context;

    public PositionDataAccessService(EmployeesDbContext context)
    {
        _context = context;
    }

    public PositionExportDTO GetPositionById(int id)
    {
        var position = _context.Positions.Where(p => p.Id == id).FirstOrDefault();
        if (position == null) { throw new NullReferenceException($"Position with ID: {id} does not exist in the Database!"); }

        return new PositionExportDTO
        {
            Id = id,
            Name = position.Name,
            MinSalary = position.MinSalary,
            MaxSalary = position.MaxSalary
        };
    }

    public PositionExportDTO GetPositionByName(string name)
    {
        var position = _context.Positions.Where(p => p.Name == name).FirstOrDefault();
        if (position == null) { throw new NullReferenceException($"Position with Name: {name} does not exist in the Database!"); }

        return new PositionExportDTO
        {
            Id = position.Id,
            Name = position.Name,
            MinSalary = position.MinSalary,
            MaxSalary = position.MaxSalary
        };
    }

    public List<PositionExportDTO> GetAllPositions()
    {
        var positions = _context.Positions.ToList();
        if (positions == null) { throw new NullReferenceException($"No Positions in the Database!"); }

        var result = new List<PositionExportDTO>();
        foreach (var position in positions)
        {
            var dto = new PositionExportDTO
            {
                Id = position.Id,
                Name = position.Name,
                MinSalary = position.MinSalary,
                MaxSalary = position.MaxSalary
            };
            result.Add(dto);
        }
        return result;
    }

    public async Task<int> CreatePosition(PositionImportDTO positionDTO)
    {
        var position = new Position
        {
            Name = positionDTO.Name,
            MinSalary = positionDTO.MinSalary,
            MaxSalary = positionDTO.MaxSalary
        };

        await _context.Positions.AddAsync(position);
        await _context.SaveChangesAsync();

        return position.Id;
    }

    public async Task UpdatePosition(int id, PositionImportDTO positionDTO)
    {
        var position = _context.Positions.Where(p => p.Id == id).FirstOrDefault();
        if (position == null) { throw new NullReferenceException($"Position with ID: {id} does not exist in the Database!"); }

        position.Name = positionDTO.Name;
        position.MinSalary = positionDTO.MinSalary;
        position.MaxSalary = positionDTO.MaxSalary;

        await _context.SaveChangesAsync();
    }

    public async Task DeletePosition(int id)
    {
        var position = _context.Positions.Where(p => p.Id == id).FirstOrDefault();
        if (position == null) { throw new NullReferenceException($"Position with ID: {id} does not exist in the Database!"); }

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync();
    }
}
