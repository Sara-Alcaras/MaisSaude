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
    public class PacientesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IPacienteRepository repositorio;

        // Método Construtor
        public PacientesController(IPacienteRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra paciente na aplicação
        /// </summary>
        /// <param name="paciente">Dados do paciente</param>
        /// <returns>Dados do paciente cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                Paciente retorno = repositorio.Inserir(paciente);

                // Retorna o paciente que foi inserido
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
        /// Lista todos os pacientes cadastrados na aplicação
        /// </summary>
        /// <returns>Lista de pacientes</returns>
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
        /// Busca todos os pacientes cadastradas por id
        /// </summary>
        /// <returns>Lista de pacientes</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPacientePorID(int id)
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
                        Message = "Paciente não encontrado"
                    });
                }
                // Retorna o paciente por id
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
        /// Alterar os dados de um paciente
        /// </summary>
        /// <param name="paciente">Todas as informações do paciente</param>
        /// <param name="id">Id do paciente</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Paciente paciente)
        {
            try
            {
                // Verifica se os ids existem
                if (id != paciente.Id)
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
                repositorio.Alterar(paciente);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchPaciente)
        {
            // Verifica se o Patch está vazio
            if (patchPaciente == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var paciente = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (paciente == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Paciente não encontrado"
                });
            }

            // Pega o patch e o paciente encontrado
            repositorio.AlterarParcialmente(patchPaciente, paciente);
            return Ok(paciente);
        }
        /// <summary>
        /// Deleta todos dados de um paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Mensagem de exclusão</returns>
        [Authorize]
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
                        Message = "Paciente não encontrado"
                    });
                }
                // Exclui por busca de id
                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Paciente exlcuído com sucesso!"
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
