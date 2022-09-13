using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <summary>
        /// Alterar os dados do usuário
        /// </summary>
        /// <param name="TipoUsuario">Todas as informações do usuário</param>
        /// <param name="id">Id do usuário</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                // Verifica se os ids existem
                if (id != usuario.Id)
                {
                    // Retorna erro
                    return BadRequest("Os ids são diferentes");
                }

                // Verifica se o id existe no banco
                var retorno = repositorio.BuscarPorId(id);

                // Se o id for nulo
                if (retorno == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Consulta não encontrada"
                    });
                }
                // Efetiva a alteração
                repositorio.Alterar(usuario);

                // Retorna sucesso, não retorna o objeto
                return NoContent();
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
        /// Altera os dados parcialmente
        /// </summary>
        /// <returns>Dados alterados</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchUsuario)
        {
            // Verifica se o Patch está vazio
            if (patchUsuario == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var usuario = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (usuario == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Usuário não encontrado"
                });
            }

            // Pega o patch e o usuário encontrado
            repositorio.AlterarParcialmente(patchUsuario, usuario);
            return Ok(usuario);
        }
    }
}
