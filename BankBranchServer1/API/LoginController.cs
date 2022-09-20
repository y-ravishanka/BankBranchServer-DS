using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Database database = new();

        [HttpGet("{nic}")]
        public ClientLogin GetClientLogin(string nic)
        {
            return database.GetLoginDetails(nic);
        }

        [HttpPost]
        [Route("setlogin/{nic:int}")]
        public void SetClientLogin([FromBody]int nic)
        {
            database.SetActivityLogin(nic);
        }

        [HttpPost]
        [Route("setlogout/{nic:int}")]
        public void SetClientLogout(int nic)
        {
            database.SetActivityLogout(nic);
        }
    }
}
