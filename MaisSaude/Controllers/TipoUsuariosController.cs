using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <summary>
        /// Alterar os dados tipo usuário
        /// </summary>
        /// <param name="TipoUsuario">Todas as informações do tipoUsuario</param>
        /// <param name="id">Id do tipoUsuario</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, TipoUsuario tipoUsuario)
        {
            try
            {
                // Verifica se os ids existem
                if (id != tipoUsuario.Id)
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
                repositorio.Alterar(tipoUsuario);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchTipoUsuario)
        {
            // Verifica se o Patch está vazio
            if (patchTipoUsuario == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var tipoUsuario = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (tipoUsuario == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Tipo Usuário não encontrado"
                });
            }

            // Pega o patch e o tipo usuário encontrado
            repositorio.AlterarParcialmente(patchTipoUsuario, tipoUsuario);
            return Ok(tipoUsuario);
        }
        /// <summary>
        /// Deleta todos dados de um tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Mensagem de exclusão</returns>
        /// 
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                // Busca por id
                var busca = repositorio.BuscarPorId(id);
                // Se busca nulo
                if (busca == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Tipo Usuário não encontrado"
                    });
                }
                // Exclui por busca de id
                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Tipo Usuário exlcuído com sucesso!"
                });


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
