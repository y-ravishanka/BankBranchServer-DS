using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        private readonly int branchid;
        private Database db = new();

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.branchid = db.GetBranchID();
        }

        public async Task<Employee> GetEmployeeById(string id)
        {
            return await httpClient.GetFromJsonAsync<Employee>("api/Employees/getbyempid/" + id);
        }

        public async Task<Employee> GetEmployeeByNic(string nic)
        {
            return await httpClient.GetFromJsonAsync<Employee>("api/Employees/getbyempnic/" + nic);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employees/getbybranchid/" + branchid);
        }
    }
}
