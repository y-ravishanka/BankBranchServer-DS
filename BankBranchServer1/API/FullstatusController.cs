using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullstatusController : ControllerBase
    {
        private Database database = new();
        private Calculations cal = new();

        [HttpGet]
        public IEnumerable<FullStatus> GetFullStatuses()
        {
            return database.GetFullStatus();
        }

        [HttpGet]
        [Route("today")]
        public FullStatus GetFullStatus()
        {
            return database.GetFullStatus_ofDate(cal.GetDate());
        }

        [HttpGet]
        [Route("ofadate/{date}")]
        public FullStatus GetFullStatus_ofDate(string date)
        {
            return database.GetFullStatus_ofDate(date);
        }
    }
}
