using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;

        public OperationsController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPut("Withdraw")]
        public async Task<ActionResult> Withdraw([FromQuery] int id, [FromQuery] double value)
        {
            int affectedRows = await _accountBusiness.Withdraw(id, value);
            if (affectedRows == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Deposit")]
        public async Task<ActionResult<int>> Deposit([FromQuery] int id, [FromQuery] double value)
        {
            int affectedRows = await _accountBusiness.Deposit(id, value);
            if (affectedRows == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Transfer")]
        public async Task<ActionResult<int>> Transfer([FromQuery] int originAccount, [FromQuery] int destinationAccount, [FromQuery] double value)
        {
            int affectedRows = await _accountBusiness.Transfer(originAccount, destinationAccount, value);
            if (affectedRows == 2)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}