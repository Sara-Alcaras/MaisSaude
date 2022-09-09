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
    }
}
