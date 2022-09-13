using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IUsuarioRepository repositorio;

        // Método Construtor
        public UsuariosController(IUsuarioRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra usuario na aplicação
        /// </summary>
        /// <param name="usuario">Dados do usuario</param>
        /// <returns>Dados do usuario cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                Usuario retorno = repositorio.Inserir(usuario);

                // Retorna o usuario que foi inserido
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
        /// Lista todos os usuários cadastrados na aplicação
        /// </summary>
        /// <returns>Lista de usuários</returns>
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
        /// Busca todos os suários cadastradas por id
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarUsuarioPorID(int id)
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
                        Message = "Usuário não encontrado"
                    });
                }
                // Retorna o usuário por id
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
