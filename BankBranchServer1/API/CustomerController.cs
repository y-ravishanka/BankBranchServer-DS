using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankBranchServer1.Data;
using BankBranchServer1.Model;

namespace BankBranchServer1.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private Database database = new();

        [HttpGet("{nic}")]
        public ActionResult<Customer> GetCustomer(string nic)
        {
            Customer customer = database.GetCustomer(0, nic);
            if(customer.id == 0)
            {
                return NotFound();
            }
            return Ok(customer);
        }

    }
}
