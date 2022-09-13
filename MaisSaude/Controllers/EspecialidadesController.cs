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

        /// <summary>
        /// Lista todas as especialidades cadastradas na aplicação
        /// </summary>
        /// <returns>Lista de especialidades</returns>
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
        /// Busca todas as especialidades cadastradas por id
        /// </summary>
        /// <returns>Lista de especialidades</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarEspecialidadePorID(int id)
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
                        Message = "Especialidade não encontrada"
                    });
                }
                // Retorna a especialidade por id
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
