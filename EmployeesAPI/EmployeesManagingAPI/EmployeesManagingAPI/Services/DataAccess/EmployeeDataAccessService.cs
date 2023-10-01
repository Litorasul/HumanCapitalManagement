using EmployeesManagingAPI.Data;
using EmployeesManagingAPI.DTOs.ExportDTOs;
using EmployeesManagingAPI.DTOs.ImoportDTOs;
using EmployeesManagingAPI.Models;

namespace EmployeesManagingAPI.Services.DataAccess;
public class EmployeeDataAccessService : IEmployeeDataAccessService
{
    private readonly EmployeesDbContext _context;
    private readonly IPositionDataAccessService _positionDataAccessService;

    public EmployeeDataAccessService(EmployeesDbContext context, IPositionDataAccessService positionDataAccessService)
    {
        _context = context;
        _positionDataAccessService = positionDataAccessService;
    }

    public EmployeeExportDTO GetEmployeeById(int id)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with ID: {id} does not exist in the Database!"); }

        return new EmployeeExportDTO
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary,
            PositionId = employee.PositionId,
            ManagerId = employee.ManagerId
        };
    }

    public EmployeeExportDTO GetEmployeeByName(string name)
    {
        var employee = _context.Employees.Where(e => e.Name == name).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with Name: {name} does not exist in the Database!"); }

        return new EmployeeExportDTO
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Salary = employee.Salary,
            PositionId = employee.PositionId,
            ManagerId = employee.ManagerId
        };
    }

    public List<EmployeeExportDTO> GetAllEmployeesForAManager(int managerId)
    {
        var manager = _context.Employees.Where(m => m.Id == managerId).FirstOrDefault();
        if (manager == null) { throw new NullReferenceException($"Employee with ID: {managerId} does not exist in the Database!"); }

        var result = new List<EmployeeExportDTO>();
        var employees = _context.Employees.Where(m => m.ManagerId == managerId).ToList();

        foreach (var employee in employees)
        {
            var dto = new EmployeeExportDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                PositionId = employee.PositionId,
                ManagerId = managerId
            };
            result.Add(dto);
        }

        return result;
    }

    public List<EmployeeExportDTO> GetAllEmployees()
    {
        var result = new List<EmployeeExportDTO>();
        var employees = _context.Employees.ToList();

        foreach (var employee in employees)
        {
            var dto = new EmployeeExportDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                PositionId = employee.PositionId,
                ManagerId = employee.ManagerId
            };
            result.Add(dto);
        }

        return result;
    }

    public List<EmployeeExportDTO> GetAllEmployeesOnAPosition(int positionId)
    {
        _positionDataAccessService.GetPositionById(positionId);

        var result = new List<EmployeeExportDTO>();
        var employees = _context.Employees.Where(p => p.PositionId == positionId).ToList();

        foreach (var employee in employees)
        {
            var dto = new EmployeeExportDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Salary = employee.Salary,
                PositionId = employee.PositionId,
                ManagerId = employee.ManagerId
            };
            result.Add(dto);
        }

        return result;
    }

    public async Task<int> CreateEmployee(EmployeeImportDTO employeeImportDTO)
    {
        var employee = new Employee
        {
            Name = employeeImportDTO.Name,
            Email = employeeImportDTO.Email,
            Salary = employeeImportDTO.Salary,
            PositionId = employeeImportDTO.PositionId,
            ManagerId = employeeImportDTO.ManagerId
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee.Id;
    }

    public async Task UpdateEmployee(int id, EmployeeImportDTO employeeImportDTO)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with ID: {id} does not exist in the Database!"); }

        employee.Name = employeeImportDTO.Name;
        employee.Email = employeeImportDTO.Email;
        employee.Salary = employeeImportDTO.Salary;
        employee.PositionId = employeeImportDTO.PositionId;
        employee.ManagerId = employeeImportDTO.ManagerId;

        await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdateManagerToEmployee(int id, int managerId)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with ID: {id} does not exist in the Database!"); }

        var manager = _context.Employees.Where(m => m.Id == managerId).FirstOrDefault();
        if (manager == null) { throw new NullReferenceException($"Employee with ID: {managerId} does not exist in the Database!"); }

        employee.ManagerId = managerId;
        await _context.SaveChangesAsync();
    }

    public async Task AddOrUpdatePositionToEmployee(int id, int positionId)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with ID: {id} does not exist in the Database!"); }

        _positionDataAccessService.GetPositionById(id);

        employee.PositionId = positionId;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null) { throw new NullReferenceException($"Employee with ID: {id} does not exist in the Database!"); }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
