using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocNetw.DAL.Repositories;
using SocNetw.Core.Models;

namespace SocNetw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IAccountRepository _accountRepository;

        public ValuesController(IAccountRepository repo)
        {
            _accountRepository = repo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _accountRepository.CreateNewAccount(
                new Credentials
                {
                    Login = "111@gmail.com",
                    Password = "1111"
                },
                new Account()
                {
                    FirstName = "111",
                    LastName = "111",
                    UniqueID = Guid.NewGuid()
                }
                );
            _accountRepository.CreateNewAccount(
                new Credentials
                {
                    Login = "1111@gmail.com",
                    Password = "1111"
                },
                new Account()
                {
                    FirstName = "112",
                    LastName = "111",
                    UniqueID = Guid.NewGuid()
                }
                );
            var finded = _accountRepository.FindAccount(x => x.FirstName == "111");
            finded.Description = "Error";
            var finded2 = _accountRepository.FindAccount(x => x.FirstName == "112");
            if (finded2 != null)
                _accountRepository.EditAccount(finded2, x => {
                    x.FirstName = "Nazar";
                });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
