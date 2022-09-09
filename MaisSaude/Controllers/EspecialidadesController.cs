using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IEspecialidadeRepository repositorio;

        // Método Construtor
        public EspecialidadesController(IEspecialidadeRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra especialidade na aplicação
        /// </summary>
        /// <param name="especialidade">Dados da especialidade</param>
        /// <returns>Dados da especialidade cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                Especialidade retorno = repositorio.Inserir(especialidade);

                // Retorna a especialidade que foi inserida
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
