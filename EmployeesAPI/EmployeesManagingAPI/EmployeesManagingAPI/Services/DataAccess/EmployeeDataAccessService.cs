using EmployeesManagingAPI.Data;
namespace EmployeesManagingAPI.Services.DataAccess
{
    public class EmployeeDataAccessService
    {
        private readonly EmployeesDbContext _context;

        public EmployeeDataAccessService(EmployeesDbContext context)
        {
            _context = context;
        }


    }
}
