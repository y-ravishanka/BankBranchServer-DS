using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Model;
using BankBranchServer1.Data;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        Database database = new();

        [HttpGet]
        public IEnumerable<ActivityLog> GetActivityLogs()
        {
            List<ActivityLog> activityLogList = database.GetActivityLog(0, 0);
            return activityLogList;
        }

        [HttpGet]
        [Route("getbyid/{id:int}")]
        public IEnumerable<ActivityLog> GetActivityLog(int id)
        {
            List<ActivityLog> activityLogList = database.GetActivityLog(1, id);
            return activityLogList;
        }
    }
}
