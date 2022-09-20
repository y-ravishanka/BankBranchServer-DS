using BankBranchServer1.Data;

namespace BankBranchServer1.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(string id);
        Task<Employee> GetEmployeeByNic(string nic);
    }
}
