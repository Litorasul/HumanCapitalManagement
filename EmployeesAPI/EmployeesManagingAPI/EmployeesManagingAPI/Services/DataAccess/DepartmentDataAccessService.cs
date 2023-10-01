using EmployeesManagingAPI.Data;
using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Models;

namespace EmployeesManagingAPI.Services.DataAccess;

public class DepartmentDataAccessService : IDepartmentDataAccessService
{
    private readonly EmployeesDbContext _context;

    public DepartmentDataAccessService(EmployeesDbContext context)
    {
        _context = context;
    }

    public DepartmentExportDTO GetDepartmentById(int id)
    {
        var department = _context.Departments.Where(d => d.Id == id).FirstOrDefault();
        if (department == null) { throw new NullReferenceException($"Department with ID: {id} does not exist in the Database!"); }

        return new DepartmentExportDTO
        {
            Id = id,
            Name = department.Name,
            DepartmentManagerId = department.DepartmentManagerId
        };
    }

    public DepartmentExportDTO GetDepartmentByName(string name)
    {
        var department = _context.Departments.Where(d => d.Name == name).FirstOrDefault();
        if (department == null) { throw new NullReferenceException($"Department with Name: {name} does not exist in the Database!"); }

        return new DepartmentExportDTO
        {
            Id = department.Id,
            Name = department.Name,
            DepartmentManagerId = department.DepartmentManagerId
        };
    }

    public async Task<int> CreateDepartment(DepartmentImportDTO dto)
    {
        var department = new Department
        {
            Name = dto.Name,
            DepartmentManagerId = dto.DepartmentManagerId
        };

        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return department.Id;
    }

    public async Task UpdateDepartment(int id, DepartmentImportDTO dto)
    {
        var department = _context.Departments.Where(d => d.Id == id).FirstOrDefault();
        if (department == null) { throw new NullReferenceException($"Department with ID: {id} does not exist in the Database!"); }

        department.Name = dto.Name;
        department.DepartmentManagerId = dto.DepartmentManagerId;

        await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateManagerToDepartment(int id, int managerId)
    {
        var department = _context.Departments.Where(d => d.Id == id).FirstOrDefault();
        if (department == null) { throw new NullReferenceException($"Department with ID: {id} does not exist in the Database!"); }

        var manager = _context.Employees.Where(m => m.Id == managerId).FirstOrDefault();
        if (manager == null) { throw new NullReferenceException($"Employee with ID: {managerId} does not exist in the Database!"); }

        department.DepartmentManagerId = managerId;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteDepartment(int id)
    {
        var department = _context.Departments.Where(d => d.Id == id).FirstOrDefault();
        if (department == null) { throw new NullReferenceException($"Department with ID: {id} does not exist in the Database!"); }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }
}
