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

        /// <summary>
        /// Lista todos os tipos de usuários cadastrados na aplicação
        /// </summary>
        /// <returns>Lista de tipo de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // Cria a variável retorno para receber o método de listar
                var retorno = repositorio.ListarTodos();
                // Retorna a variável
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {

                // Se não for inserida da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
        /// <summary>
        /// Busca todos os tipo de usuários cadastradas por id
        /// </summary>
        /// <returns>Lista de tipo de usuários</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarTipoUsuarioPorID(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);

                // Se o id for nulo
                if (retorno == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Tipo de Usuário não encontrado"
                    });
                }
                // Retorna o tipo de usuário por id
                return Ok(retorno);

            }
            catch (System.Exception ex)
            {
                // Se não for inserida da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
    }
}
