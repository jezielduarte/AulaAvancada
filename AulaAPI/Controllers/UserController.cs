using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AulaAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(User user)
        {
            _repository.Save(user);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string user, string senha)
        {
            //1º passo gerar claim: ATRIBUTOS
            List<Claim> clains = new List<Claim>();
            clains.Add(new Claim(ClaimTypes.Name, user));
            clains.Add(new Claim(ClaimTypes.Email, "email@email.com"));

            //Permissoes
            clains.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entity.User.CreateCustomer)));
            clains.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entity.User.DeleteCustomer)));
            clains.Add(new Claim(ClaimTypes.Role, nameof(Domain.Entity.User.UpdateCustomer)));

            //2º passo gerar a identidade
            ClaimsIdentity identity = new ClaimsIdentity(clains, "User", ClaimTypes.Name, ClaimTypes.Role);

            ClaimsPrincipal principal = new ClaimsPrincipal(new[] { identity });

            HttpContext.SignInAsync(principal);

            return Ok();
        }

        //[HttpPost]
        //public IActionResult Logout()
        //{
        //    HttpContext.SignOutAsync();
        //    return Ok();
        //}
    }
}
