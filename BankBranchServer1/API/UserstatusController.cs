using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserstatusController : ControllerBase
    {
        private Database database = new();
        private Calculations cal = new();

        [HttpGet("{nic}")]
        public UserStatus GetUserStatus(string nic)
        {
            return database.GetUserStatus_a(cal.GetDate(), nic);
        }
    }
}
