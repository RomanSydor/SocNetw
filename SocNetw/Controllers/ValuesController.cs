using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocNetw.Core.Models;
using SocNetw.DAL.Repositories;

namespace SocNetw.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IAccountRepository _accountRepository;

        public ValuesController(IAccountRepository repo)
        {
            _accountRepository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var nameIdentifier = this.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

           
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
            if (finded != null)
            {
                _accountRepository.EditAccount(finded, x => {
                    x.Description = "Error";
                });
            }

            var finded2 = _accountRepository.FindAccount(x => x.FirstName == "112");
            if (finded2 != null)
                _accountRepository.EditAccount(finded2, x => {
                    x.FirstName = "Nazar";
                });


            return new string[] { nameIdentifier?.Value, "value1", "value2" };
        }

    }
}