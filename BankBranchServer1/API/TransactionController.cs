using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private Database db = new();

        [HttpGet]
        [Route("bydate/{date}")]
        public IEnumerable<Transaction> GetTransactions(string date)
        {
            return db.GetTransactions_all(1, date);
        }

        [HttpGet]
        [Route("byid/{id}")]
        public Transaction GetTransaction(string id)
        {
            return db.GetTransaction(id);
        }
    }
}
