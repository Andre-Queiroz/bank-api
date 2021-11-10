using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Entities;
using Business.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountsController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> Get(int id)
        {
            Account account = await _accountBusiness.GetAccount(id);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAll()
        {
            IEnumerable<Account> list = await _accountBusiness.GetAccounts();
            if (list != null)
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Account account)
        {
            int affectedRows = await _accountBusiness.Create(account);
            if (affectedRows != 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Account>> Update([FromBody] Account account)
        {
            int affectedRows = await _accountBusiness.Update(account);
            if (affectedRows != 0)
            {
                return Ok(account);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            int affectedRows = await _accountBusiness.Delete(id);
            if (affectedRows != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}