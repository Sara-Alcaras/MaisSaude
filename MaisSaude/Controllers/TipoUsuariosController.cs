using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly ITipoUsuarioRepository repositorio;

        // Método Construtor
        public TipoUsuariosController(ITipoUsuarioRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra tipo de usuário na aplicação
        /// </summary>
        /// <param name="tipoUsuario">Dados do tipo de usuário</param>
        /// <returns>Dados do tipo de usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario retorno = repositorio.Inserir(tipoUsuario);

                // Retorna o tipo usuário que foi inserido
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                // Se não for inserido da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
    }
}
