using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private Database database = new();

        //public Employee GetEmployee(string nic)
        //{
        //    return database.
        //}
    }
}
