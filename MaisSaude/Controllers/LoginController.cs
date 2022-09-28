using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly ILoginRepository repositorio;

        // Método Construtor
        public LoginController(ILoginRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Logar usuario na aplicação
        /// </summary>
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var logar = repositorio.Logar(email, senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }

    }
}
