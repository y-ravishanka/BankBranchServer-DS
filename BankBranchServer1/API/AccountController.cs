using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private Database db = new();

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Account> GetAccounts()
        {
            AccountNevData nevData = new AccountNevData
            {
                nev = 3,
                branch = db.GetBranchID()
            };
            return db.GetAccounts_byAll(nevData);
        }

        [HttpGet]
        [Route("byaccnumber/{id:int}")]
        public Account GetAccount(int id)
        {
            return db.GetAccount(id);
        }

        [HttpPost]
        [Route("createaccount")]
        public void CreateAccount(Account acc)
        {
            int t = db.GetLastAccountNum();
            acc.branchid = db.GetBranchID();
            string s = db.GetBranchID().ToString() + (t + 1).ToString();
            acc.number = Convert.ToInt32(s);
            db.CreateAcoount(acc);
        }
    }
}
