using BankBranchServer1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemDataController : ControllerBase
    {
        private Database db = new();

        [HttpGet]
        [Route("getbranchid")]
        public int GetBranchID()
        {
            return db.GetBranchID();
        }
    }
}
