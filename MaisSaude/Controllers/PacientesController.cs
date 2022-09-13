using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
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
    }
}
